using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class VendedoresRepository : BaseRepository<B2BSolution, Vendedores>
    {
        public Vendedores GetVendedores(int idVendedor)
        {
            LazyLoadingEnabled();
            return DbSet.FirstOrDefault(v => v.IdVendedor == idVendedor);
        }

        public List<Vendedores> GetTodos()
        {
            LazyLoadingEnabled();
            return DbSet.ToList();
        }
    }
}
