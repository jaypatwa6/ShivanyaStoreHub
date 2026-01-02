using Microsoft.EntityFrameworkCore;
using SSH.Framework.Logging;
using SSH.Framework.Model.EntityBase;
using SSH.Framework.Utilities;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence.Infrastructure
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
        protected readonly DataContextBase DataContext;
        public bool IsTracking { set; private get; }
        public Collection<Expression<Func<TEntity, object>>> Includes { get; private set; }

        protected RepositoryBase(DataContextBase dataContext)
        {
            IsTracking = false;
            Includes = new Collection<Expression<Func<TEntity, object>>>();
            DataContext = dataContext;
            DefaultLogger.Instance.DebugCreateInstance(new LogSegment(this, string.Empty));
        }

        protected DbSet<TEntity> EntitySet
        {
            get
            {
                return DataContext.Set<TEntity>();
            }
        }

        protected IQueryable<TEntity> Query
        {
            get
            {
                var query = EntitySet as DbQuery<TEntity>;
                if (!IsTracking)
                {
                    query = query.AsNoTracking();
                }

                return Includes.Aggregate(query, (current, include) => current.Include(ExpressionHelper.GetAccessPath(include)));
            }
        }

        public TEntity GetOneById(TKey id)
        {
            try
            {
                return EntitySet.Find(id);
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(GetOneById));
            }
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Get(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(GetOne));
            }
        }

        public TMappedEntity GetOne<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector, Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Get(predicate).Select(selector).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, $"{nameof(GetOne)}<{typeof(TMappedEntity).Name}>");
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(GetAll));
            }
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return predicate != null ? Query.Where(predicate) : Query;
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(Get));
            }
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return Get(predicate).Count();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(Count));
            }
        }

        public bool CheckExist(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return Get(predicate).Any();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(CheckExist));
            }
        }

        protected static Exception BuildDataException(System.Exception exception, string methodName)
        {
            return new Exception(string.Format("Error on executing Repository<{0}>.{1}", typeof(TEntity).Name, methodName), exception);
        }
    }

}
