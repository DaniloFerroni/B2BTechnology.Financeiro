
namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(int codigo);

        void Inserir(TEntity entity);
    }
}
