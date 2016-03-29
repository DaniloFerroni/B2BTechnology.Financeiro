using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ContatoRepository : BaseRepository<B2BSolution, Contato>
    {
        public void Salvar(Contato contato)
        {
            if (contato.IdContato == 0)
                Inserir(contato);
            else
                Alterar(contato);

            contato.IdContato = Context.SaveChanges();
        }

        private void Alterar(Contato contato)
        {
            var contatoAtual = DbSet.First(c => c.IdContato == contato.IdContato);
            contatoAtual.Celular = contato.Celular;
            contatoAtual.Email = contato.Email;
            contatoAtual.Telefone = contato.Telefone;
            contatoAtual.Nome = contato.Nome;
        }
    }
}
