using SSH.Framework.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace SSH.Framework.Persistence.Infrastructure
{
    public abstract class DataModelConfigurationBase : IDataModelConfiguration
    {
        public virtual void ApplyToBuilder(DbModelBuilder modelBuilder)
        {
            RegisterConventions(modelBuilder.Conventions);
            RegisterValueObjectTypes(modelBuilder);
            RegisterMappings(modelBuilder.Configurations);
        }

        private void RegisterMappings(ConfigurationRegistrar configurations)
        {
            
        }

        private void RegisterValueObjectTypes(DbModelBuilder modelBuilder)
        {
            
        }

        private void RegisterConventions(ConventionsConfiguration conventions)
        {
            
        }
    }
}
