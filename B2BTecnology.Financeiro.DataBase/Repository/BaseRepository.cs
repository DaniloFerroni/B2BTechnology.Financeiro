using System;
using System.Data.Entity;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class BaseRepository<TContext, TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private DbContext _context;

        public BaseRepository()
        {
            BaseContrutor(null);
        }

        public BaseRepository(DbContext context)
        {
            BaseContrutor(context);
        }

        public void BaseContrutor(DbContext context)
        {
            _context = context ?? (DbContext)((object)Activator.CreateInstance<TContext>());
        }

        public void LazyLoadingEnabled()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public TContext Context
        {
            get 
            { 
                return (TContext)((object)_context);
            }
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int codigo)
        {
            var entity = DbSet.Find(codigo);
            DbSet.Remove(entity);
        }

        public void Inserir(TEntity entity)
        {
            DbSet.Add(entity);
        }
    }
}
