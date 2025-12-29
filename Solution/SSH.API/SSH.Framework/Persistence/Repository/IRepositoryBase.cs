using SSH.Framework.Model.EntityBase;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence
{
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        bool IsTracking { set; }

        Collection<Expression<Func<TEntity, object>>> Includes { get; }

        TEntity GetOneById(TKey id);

        TEntity GetOne(Expression<Func<TEntity, bool>> predicate);

        TEntity GetOne<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector, Expression<Func<TEntity, object>> predicate);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        bool CheckExist(Expression<Func<TEntity, bool>> predicate = null);
    }
}
