namespace SSH.Framework.Model.EntityBase
{
    public abstract class AuditedEntity<TIdentityType>: Entity<TIdentityType>, IAuditableEntity
    {
        /// <summary>
        /// Time of record created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Time of record modified
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// The user created
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// The user modified
        /// </summary>
        public Guid ModifiedBy { get; set; }
    }

    public abstract class AuditedEntity : AuditedEntity<Guid>
    {

    }

    public abstract class AuditedLongEntity : AuditedEntity<long>
    {

    }
}
