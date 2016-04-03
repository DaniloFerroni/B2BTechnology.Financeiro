using System.Collections.Generic;
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
            
            Context.SaveChanges();
        }

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
    }
}
