using System.ComponentModel.DataAnnotations;

namespace SSH.Framework.Model.EntityBase
{
    public abstract class EntityBase
    {
    }

    public abstract class Entity<TIdentityType> : EntityBase
    {
        [Key]
        public TIdentityType Id { get; set; }

        #region Idenity Management

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Entity<TIdentityType>)obj;
            return base.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }

    public abstract class Entity : Entity<Guid>
    {

    }

    public abstract class LongEntity : Entity<long>
    {

    }
}
