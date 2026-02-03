using SSH.Framework.Model.EntityBase;
using SSH.Framework.Persistence.Repository;

namespace SSH.Module.Administration.Domain.Repositories.Read
{
    public interface IAdministrationMasterReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
    }

    public interface IAdministrationMasterReadOnlyRepositoryOfLongIdentity<TEntity> : IReadOnlyRepositoryForLongIdentity<TEntity> where TEntity : LongEntity
    {
    }
}
