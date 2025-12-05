using SSH.Framework.Model.EntityBase;

namespace SSH.Framework.Persistence.Repository
{
    public interface IReadOnlyRepository<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        List<Entity> GetList();/// Pending

        List<TMappedEntity> GetList<TMappedEntity>(); /// Pending

        // other pending
    }
}
