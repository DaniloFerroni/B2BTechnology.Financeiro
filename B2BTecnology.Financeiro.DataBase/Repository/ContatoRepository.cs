using System.Collections.Generic;
using System.Data.Entity;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ContatoRepository : BaseRepository<B2BSolution, Contato>
    {
        public void Incluir(List<Contato> contatos)
        {
            contatos.ForEach(c => DbSet.Add(c));
            
            Context.SaveChanges();
        }

        //public void Alterar(Contato contato)
        //{
        //    var entry = Context.Entry(contato);
        //    entry.State = EntityState.Modified;

        //    entry.Property(p => p.Celular).IsModified = true;
        //    entry.Property(p => p.Email).IsModified = true;
        //    entry.Property(p => p.Telefone).IsModified = true;
        //    entry.Property(p => p.Nome).IsModified = true;
            
        //    Context.SaveChanges();
        //}

        public void Excluir(List<Contato> contatos)
        {
            contatos.ForEach(c =>
            {
                var entry = Context.Entry(c);
                entry.State = EntityState.Deleted; 
            });

            Context.SaveChanges();
        }
    }
}
