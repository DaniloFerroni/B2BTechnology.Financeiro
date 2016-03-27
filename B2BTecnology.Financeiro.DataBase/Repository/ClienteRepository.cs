using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ClienteRepository : BaseRepository<B2BSolution, Cliente>
    {
        public Cliente GetCliente(string documento)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contato")
                .Include("Endereco")
                .Include("Contratos")
                .FirstOrDefault(c => c.Documento == documento);
        }

        public List<Cliente> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet
                    .Include("Contratos")
                    .Include("Contratos.Vendedores")
                    .ToList();
        }

        public void Salvar(Cliente cliente)
        {
            var informacoesPessoais = new InformacoesPessoais();
            informacoesPessoais.Salvar(cliente.Contato, cliente.Endereco);
        }
    }
}
