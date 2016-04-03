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
            //var contatoAtual = DbSet.First(c => c.IdContato == contato.IdContato);
            contato.Celular = contato.Celular;
            contato.Email = contato.Email;
            contato.Telefone = contato.Telefone;
            contato.Nome = contato.Nome;
            
            Context.SaveChanges();
        }
    }
}
