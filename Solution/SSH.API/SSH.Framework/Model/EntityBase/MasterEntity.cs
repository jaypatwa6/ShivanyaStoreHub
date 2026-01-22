namespace SSH.Framework.Model.EntityBase
{
    public abstract class MasterEntity<TIdentityBase> : AuditedEntity<TIdentityBase>, IActiveEntity
    {
        public bool IsActive { get; set; }
    }

    public abstract class MasterEntity : MasterEntity<Guid> { }

    public abstract class MasterLongEntity : MasterEntity<long> { }

}
