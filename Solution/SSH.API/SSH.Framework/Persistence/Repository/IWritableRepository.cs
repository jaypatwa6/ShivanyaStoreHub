using SSH.Framework.Model.EntityBase;
using System.Linq.Expressions;

namespace SSH.Framework.Persistence.Repository
{
    public interface IWritableRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : Entity<TKey>
    {
        #region Insert and Update

        void Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        TEntity Update(TKey id, object mappedEntity);

        void UpdateRange(IDictionary<TKey, object> mappedEntities);

        void InsertOrUpdate(TEntity entity);

        #endregion

        #region Delete

        void Delete(TEntity entity);

        void DeleteById(TKey id);

        void DeleteByIds(IEnumerable<TKey> ids);

        void DeleteRange(IEnumerable<TEntity> entities);

        int Delete(Expression<Func<TEntity, bool>> predicate = null);

        #endregion

        int ExecuteSqlCommand(string sqlCommand, params object[] args);

        Task<int> SaveChanges();

        Task<int> SaveChanges(bool useEntityAuditUserInfo);

        #region Performance Relations

        void EnableAutoDetectChanges();

        void DisableAutoDetectChanges();

        #endregion
    }

    public interface IWritableRepository<TEntity> : IWritableRepository<TEntity, Guid> where TEntity : Entity { }

    public interface IWritableRepositoryForLongIdentity<TEntity> : IWritableRepository<TEntity, long> where TEntity : LongEntity { }
}
