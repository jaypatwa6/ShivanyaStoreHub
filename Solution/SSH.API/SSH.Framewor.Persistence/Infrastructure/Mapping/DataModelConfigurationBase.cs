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

        protected virtual void RegisterMappings(ConfigurationRegistrar configurations)
        {

        }

        protected virtual void RegisterValueObjectTypes(DbModelBuilder modelBuilder)
        {

        }

        protected virtual void RegisterConventions(ConventionsConfiguration conventions)
        {

        }
    }
}
