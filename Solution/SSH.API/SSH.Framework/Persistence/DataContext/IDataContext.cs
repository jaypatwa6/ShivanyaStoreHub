using SSH.Framework.Model.EntityBase;


namespace SSH.Framework.Persistence
{
    public interface IDataContext : IDisposable
    {
        Guid InstanceId { get; }

        bool IsDisposed { get; }

        void Dispose(bool disposing);
        string GetTableName<TEntity>() where TEntity : EntityBase;
    }
}
