using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ClienteRepository : BaseRepository<B2BSolution, Cliente>
    {
        public void Incluir(Cliente cliente)
        {
            DbSet.Add(cliente);
            Context.SaveChanges();
        }

        public void Alterar(Cliente cliente)
        {
            var entry = Context.Entry(cliente);
            entry.State = EntityState.Modified;

            entry.Property(p => p.Nome).IsModified = true;
            entry.Property(p => p.TipoPessoa).IsModified = true;
            entry.Property(p => p.Apelido).IsModified = true;

            Context.SaveChanges();
        }

        public void Excluir(int idCliente)
        {
            LazyLoadingEnabled();
            var cliente = DbSet
                            .Include("Contato")
                            .Include("Endereco")
                            .First(c => c.IdCliente == idCliente);

            var endereco = cliente.Endereco;
            var contato = cliente.Contato;

            var entry = Context.Entry(cliente);
            entry.State = EntityState.Deleted;
            Context.SaveChanges();

            var enderecoRepository = new EnderecoRepository();
            if (endereco != null) enderecoRepository.Excluir(endereco);

            var contatoRepository = new ContatoRepository();
            if (contato != null) contatoRepository.Excluir(contato);
        }

        public Cliente GetCliente(string documento)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contato")
                .Include("Endereco")
                .Include("Contratos")
                .Include("Contratos.EquipamentoContrato")
                .Include("Contratos.EquipamentoContrato.Equipamentos")
                .Include("Contratos.ContratoAssinaturas")
                .FirstOrDefault(c => c.Documento == documento);
        }

        public Cliente GetClienteId(int clienteId)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contato")
                .Include("Contratos")
                .Include("Contratos.EquipamentoContrato")
                .Include("Contratos.EquipamentoContrato.Equipamentos")
                .First(c => c.IdCliente == clienteId);
        }


        public List<Cliente> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet
                    .Include("Contratos")
                    .Include("Contratos.Vendedores")
                    .ToList();
        }
    }
}
