using System.Data.Entity;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ContatoRepository : BaseRepository<B2BSolution, Contato>
    {
        public void Incluir(Contato contato)
        {
            DbSet.Add(contato);

            Context.SaveChanges();
        }

        public void Alterar(Contato contato)
        {
            var entry = Context.Entry(contato);
            entry.State = EntityState.Modified;

            entry.Property(p => p.Celular).IsModified = true;
            entry.Property(p => p.Email).IsModified = true;
            entry.Property(p => p.Telefone).IsModified = true;
            entry.Property(p => p.Nome).IsModified = true;
            
            Context.SaveChanges();
        }
    }
}
