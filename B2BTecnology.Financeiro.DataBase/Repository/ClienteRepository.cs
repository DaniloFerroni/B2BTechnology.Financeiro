using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ClienteRepository : BaseRepository<B2BSolution, Cliente>
    {
        public int Incluir(Cliente cliente)
        {
            DbSet.Add(cliente);
            return Context.SaveChanges();
        }

        public void Alterar(Cliente cliente)
        {
            Context.Enderecos.Attach(cliente.Endereco);
            var entryEndereco = Context.Entry(cliente.Endereco);
            entryEndereco.State = EntityState.Modified;

            entryEndereco.Property(p => p.Rua).IsModified = true;
            entryEndereco.Property(p => p.Numero).IsModified = true;
            entryEndereco.Property(p => p.Complemento).IsModified = true;
            entryEndereco.Property(p => p.Bairro).IsModified = true;
            entryEndereco.Property(p => p.Cep).IsModified = true;
            entryEndereco.Property(p => p.Cidade).IsModified = true;
            entryEndereco.Property(p => p.Estado).IsModified = true;
            
            DbSet.Attach(cliente);
            var entry = Context.Entry(cliente);
            
            entry.State = EntityState.Unchanged;

            entry.Property(p => p.Documento).IsModified = true;
            entry.Property(p => p.TipoPessoa).IsModified = true;
            entry.Property(p => p.Nome).IsModified = true;
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
            var contato = cliente.Contatos;

            var entry = Context.Entry(cliente);
            entry.State = EntityState.Deleted;
            Context.SaveChanges();

            var enderecoRepository = new EnderecoRepository();
            if (endereco != null) enderecoRepository.Excluir(endereco);

            //var contatoRepository = new ContatoRepository();
            //if (contato != null) contatoRepository.Excluir(contato);
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

        public Cliente GetClienteBasic(int clienteId)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include(c => c.Contatos)
                .Include(c => c.Endereco)
                .First(c => c.IdCliente == clienteId);
        }

        public List<Cliente> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet.ToList();
        }
    }
}
