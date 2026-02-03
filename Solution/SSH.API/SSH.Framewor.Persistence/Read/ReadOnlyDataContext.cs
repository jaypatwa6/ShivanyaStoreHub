using Microsoft.EntityFrameworkCore;
using SSH.Framework.Context;
using SSH.Framework.Infrastructure;
using SSH.Framework.Logging;
using SSH.Framework.Persistence.Infrastructure;

namespace SSH.Framework.Persistence.Read
{
    public abstract class ReadOnlyDataContext : DataContextBase, IQueryDataContext
    {
        protected ReadOnlyDataContext(DbContextOptions options, IDataModelConfiguration dataModelConfiguration, ApplicationContext applicationContext, ILogger logger)
            : base(options, dataModelConfiguration, applicationContext, logger)
        {

        }
    }

    public class ReadOnlyDataContext<TContextConfigure> : ReadOnlyDataContext where TContextConfigure : IDataModelConfiguration
    {
        public ReadOnlyDataContext(DbContextOptions options, IDataModelConfiguration dataModelConfiguration, ApplicationContext applicationContext, ILogger logger)
            : base(options, dataModelConfiguration, applicationContext, logger)
        {
        }
    }
}
