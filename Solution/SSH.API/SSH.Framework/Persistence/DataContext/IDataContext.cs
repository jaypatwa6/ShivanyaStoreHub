using SSH.Framework.Model.EntityBase;


namespace SSH.Framework.Persistence
{
    public interface IDataContext : IDisposable
    {
        Guid InstanceId { get; }

        bool IsDisposed { get; }

        string GetTableName<TEntity>() where TEntity : EntityBase;
    }
}
