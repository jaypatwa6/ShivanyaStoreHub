namespace SSH.Framework.Model
{
    public interface IAuditableEntity
    {
        /// <summary>
        /// Time of record created
        /// </summary>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Time of record modified
        /// </summary>
        DateTime DateModified { get; set; }

        /// <summary>
        /// The user created
        /// </summary>
        Guid CreatedBy { get; set; }

        /// <summary>
        /// The user modified
        /// </summary>
        Guid ModifiedBy { get; set; }
    }
}
