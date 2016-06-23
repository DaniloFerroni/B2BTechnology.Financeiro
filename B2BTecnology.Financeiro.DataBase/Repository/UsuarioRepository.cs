using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class UsuarioRepository : BaseRepository<B2BSolution, Usuario>
    {
        public Usuario GetUsuario(string login, string senha)
        {
            return DbSet.FirstOrDefault(u => u.Login == login && u.Senha == senha);
        }
    }
}
