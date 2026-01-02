using Microsoft.EntityFrameworkCore;
using SSH.Framework.Model.EntityBase;
using SSH.Framework.Model.QueryObjects;
using SSH.Framework.Persistence.Infrastructure;
using SSH.Framework.Persistence.Repository;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence.Read
{
    public abstract class ReadOnlyRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>, IReadOnlyRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
        protected ReadOnlyRepository(ReadOnlyDataContext dbContext)
            : base(dbContext) { }

        #region Methods

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
                    Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
                    params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            try
            {
                var query = BuildQuery(filter, orderedQueryableBuilder, includedParentReferences);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, nameof(GetList));
            }
        }

        public List<TMappedEntity> GetList<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            try
            {
                var query = BuildQuery(filter, orderedQueryableBuilder, includedParentReferences).Select(selector);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, $"{nameof(GetList)}<{typeof(TMappedEntity).Name}>");
            }
        }

        public PagedList<TEntity> GetPaged(PageInfo pageInfo, Expression<Func<TEntity, bool>> filter = null,
            Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            try
            {
                var query = BuildQuery(filter, orderedQueryableBuilder, includedParentReferences);
                return new PagedList<TEntity>(query, pageInfo);
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, $"{nameof(GetPaged)}");
            }
        }

        public PagedList<TMappedEntity> GetPaged<TMappedEntity>(Expression<Func<TEntity, TMappedEntity>> selector,
            PageInfo pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includedParentReferences)
        {
            try
            {
                var query = BuildQuery(filter, orderedQueryableBuilder, includedParentReferences).Select(selector);
                return new PagedList<TMappedEntity>(query, pageInfo);
            }
            catch (Exception ex)
            {
                throw BuildDataException(ex, $"{nameof(GetPaged)}<{typeof(TMappedEntity).Name}>");
            }
        }

        public IQueryable<TEntity> SelectQuery(string sqlQueryStatement,
            params object[] parameters)
        {
            try
            {
                return EntitySet.FromSqlRaw(sqlQueryStatement, parameters);
            }
            catch (System.Exception exception)
            {
                throw BuildDataException(exception, "SelectQuery");
            }
        }

        #endregion

        private IQueryable<TEntity> BuildQuery(Expression<Func<TEntity, bool>> filter = null,
            Func<IOrderedQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedQueryableBuilder = null,
            params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            var query = Query;

            if (includeExpressions != null && includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderedQueryableBuilder != null)
            {
                query = orderedQueryableBuilder((IOrderedQueryable<TEntity>)query);
            }
            else
            {
                query = query.OrderBy(o => o.Id);
            }

            return query;
        }
    }

    public abstract class ReadOnlyRepository<TEntity> : ReadOnlyRepository<TEntity, Guid>, IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        protected ReadOnlyRepository(ReadOnlyDataContext dataContext)
            : base(dataContext)
        {
        }
    }

    /// <summary>
    /// A advanced repository for complex querying data purposes for long datatype identity
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class ReadOnlyRepositoryOfLongIdentity<TEntity> : ReadOnlyRepository<TEntity, long>, IReadOnlyRepositoryForLongIdentity<TEntity> where TEntity : LongEntity
    {
        protected ReadOnlyRepositoryOfLongIdentity(ReadOnlyDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
