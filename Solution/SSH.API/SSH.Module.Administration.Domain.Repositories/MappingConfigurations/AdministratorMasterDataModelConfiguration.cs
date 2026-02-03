using SSH.Framework.Persistence.Infrastructure;
using SSH.Module.Common.Domain.Mapping.Master;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace SSH.Module.Administration.Domain.Repositories.MappingConfigurations
{
    public class AdministratorMasterDataModelConfiguration : DataModelConfigurationBase
    {
        protected override void RegisterMappings(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(new AccountMap());
        }
    }
}
