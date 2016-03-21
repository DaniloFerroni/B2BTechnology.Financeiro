using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ClienteRepository : BaseRepository<B2BSolution, Cliente>
    {
        public Cliente GetCliente(int idCliente)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contato")
                .Include("Endereco")
                .FirstOrDefault(c => c.IdCliente == idCliente);
        }

        public List<Cliente> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet.ToList();
        }

        public void Salvar(Cliente cliente)
        {
            var informacoesPessoais = new InformacoesPessoais();
            informacoesPessoais.Salvar(cliente.Contato, cliente.Endereco);
        }
    }
}
