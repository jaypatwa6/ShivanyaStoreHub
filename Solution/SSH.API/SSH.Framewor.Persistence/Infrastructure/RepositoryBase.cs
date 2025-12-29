using SSH.Framework.Model.EntityBase;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence.Infrastructure
{
    public abstract class RepositoryBase<TEntity, TKey>: IRepositoryBase<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
        protected readonly DataContextBase DataContext;
        public bool IsTracking { set; private get; }
        public Collection<Expression<Func<TEntity, object>>> Includes { get; private set; }

        protected RepositoryBase(DataContextBase dataContext)
        {
            DataContext = dataContext;
        }
    }
}
