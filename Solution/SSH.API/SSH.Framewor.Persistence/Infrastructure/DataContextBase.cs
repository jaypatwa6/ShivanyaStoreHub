using Microsoft.EntityFrameworkCore;
using SSH.Framework.Context;
using SSH.Framework.Infrastructure;
using SSH.Framework.Logging;
using SSH.Framework.Model.EntityBase;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

namespace SSH.Framework.Persistence.Infrastructure
{
    public abstract class DataContextBase : DbContext, IDataContext
    {
        #region Private Fields
        private readonly IDataModelConfiguration _dataModelConfiguration;
        protected readonly ApplicationContext _applicationContext;
        protected readonly ILogger _logger;
        protected readonly LogSegment _logSegment;
        #endregion Private Fields

        public Guid InstanceId { get; private set; }
        public bool IsDisposed { get; private set; }

        protected DataContextBase(DbContextOptions options, IDataModelConfiguration dataModelConfiguration, ApplicationContext applicationContext, ILogger logger)
            : base(options)
        {
            InstanceId = Guid.NewGuid();
            _dataModelConfiguration = dataModelConfiguration;
            _applicationContext = applicationContext;
            _logger = logger;

            _logSegment = new LogSegment(this, string.Format("(TxId={0})::'{1}'#{2}", applicationContext.TransactionId, Database.GetDbConnection().Database, InstanceId));
            _logger.DebugCreateInstance(_logSegment);

            //Database.Logs = s => _logger.LogSqlStatement(Database.Connection.Database, InstanceId.ToString(), s);
        }

        public void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // free other managed objects that implement
                    // IDisposable only
                }

                // release any unmanaged objects
                // set object references to null

                IsDisposed = true;
            }

            _logger.Debug(_logSegment, "DISPOSED!!!");

            base.Dispose();
        }

        public string GetTableName<TEntity>() where TEntity : EntityBase
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            var sql = objectContext.CreateObjectSet<TEntity>().ToTraceString();
            var regex = new Regex("FROM (?<table>.*) AS");
            var match = regex.Match(sql);

            var table = match.Groups["table"].Value;
            return table;
        }
    }
}
