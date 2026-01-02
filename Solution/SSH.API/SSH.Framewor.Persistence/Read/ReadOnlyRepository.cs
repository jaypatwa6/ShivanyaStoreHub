using SSH.Framework.Model.EntityBase;
using SSH.Framework.Model.QueryObjects;
using SSH.Framework.Persistence.Infrastructure;
using SSH.Framework.Persistence.Repository;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence.Read
{
    public class ReadOnlyRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>, IReadOnlyRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
        protected ReadOnlyRepository(ReadOnlyDataContext dbContext)
            : base(dbContext) { }

        public List<Entity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null, params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            throw new NotImplementedException();
        }

        public List<TMappedEntity> GetList<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null, params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            throw new NotImplementedException();
        }

        public PagedList<TEntity> GetPaged(PageInfo pageInfo, Expression<Func<TEntity, bool>> filter = null, Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null, params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            throw new NotImplementedException();
        }

        public PagedList<TMappedEntity> GetPaged<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector, PageInfo pageInfo, Expression<Func<TEntity, bool>> filter = null, Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null, params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectQuery(string sqlQueryStatement, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
