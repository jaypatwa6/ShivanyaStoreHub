using SSH.Framework.Model.EntityBase;
using SSH.Framework.Persistence.Read;
using SSH.Module.Administration.Domain.Repositories.MappingConfigurations;

namespace SSH.Module.Administration.Domain.Repositories.Read.Impl
{
    public class AdministrationMasterReadOnlyRepository<TEntity> : ReadOnlyRepository<TEntity>,
        IAdministrationMasterReadOnlyRepository<TEntity> where TEntity : Entity
    {
        public AdministrationMasterReadOnlyRepository(ReadOnlyDataContext<AdministratorMasterDataModelConfiguration> dataContext) : base(dataContext)
        {
        }
    }

    public class AdministrationMasterReadOnlyOfLongIdentityRepository<TEntity> : ReadOnlyRepositoryOfLongIdentity<TEntity>,
        IAdministrationMasterReadOnlyRepositoryOfLongIdentity<TEntity> where TEntity : LongEntity
    {
        public AdministrationMasterReadOnlyOfLongIdentityRepository(ReadOnlyDataContext<AdministratorMasterDataModelConfiguration> dataContext) : base(dataContext)
        {
        }
    }
}
