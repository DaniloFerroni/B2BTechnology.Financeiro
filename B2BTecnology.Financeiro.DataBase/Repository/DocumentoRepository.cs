using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class DocumentoRepository : BaseRepository<B2BSolution , Documento>
    {
        public Documento GetDocumento()
        {
            LazyLoadingEnabled();
            return DbSet.First();
        }
    }
}
