using SSH.Framework.Model.EntityBase;
using SSH.Framework.Model.QueryObjects;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence.Repository
{
    public interface IReadOnlyRepository<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        List<Entity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IOrderedQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences);

        List<TMappedEntity> GetList<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector,
            Expression<Func<TEntity, bool>> filter = null, Func<IOrderedQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences);

        PagedList<TEntity> GetPaged(PageInfo pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences);

        PagedList<TMappedEntity> GetPaged<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector,
            PageInfo pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences);

        IQueryable<TEntity> SelectQuery(string sqlQueryStatement, params object[] parameters);
    }

    public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity, Guid> where TEntity : Entity { }

    public interface IReadOnlyRepositoryForLongIdentity<TEntity> : IReadOnlyRepository<TEntity, long> where TEntity : LongEntity { }

}
