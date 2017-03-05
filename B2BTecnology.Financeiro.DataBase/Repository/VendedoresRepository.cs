using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class VendedoresRepository : BaseRepository<B2BSolution, Vendedores>
    {
        public Vendedores GetVendedor(string documento)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Endereco")
                .Include("Contato")
                .FirstOrDefault(v => v.Documento == documento);
        }

        public Vendedores GetVendedores(int idVendedor)
        {
            LazyLoadingEnabled();
            return DbSet.FirstOrDefault(v => v.IdVendedor == idVendedor);
        }

        public List<Vendedores> Todos()
        {
            LazyLoadingEnabled();
            return DbSet.ToList();
        }

        public void Incluir(Vendedores vendedor)
        {
            DbSet.Add(vendedor);
            Context.SaveChanges();
        }

        public void Alterar(Vendedores vendedor)
        {
            var entry = Context.Entry(vendedor);
            entry.State = EntityState.Modified;

            entry.Property(p => p.Nome).IsModified = true;
            entry.Property(p => p.Documento).IsModified = true;
            entry.Property(p => p.Comissao).IsModified = true;
            entry.Property(p => p.TipoVendedor).IsModified = true;
            entry.Property(p => p.SuperiorId).IsModified = true;

            Context.SaveChanges();
        }
    }
}
