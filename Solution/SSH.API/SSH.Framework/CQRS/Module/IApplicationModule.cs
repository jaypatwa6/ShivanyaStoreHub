namespace SSH.Framework.CQRS
{
    public interface IApplicationModule
    {
        /// <summary>
        /// Gets the business units.
        /// </summary>
        /// <value>
        /// The business units.
        /// </value>
        IList<IBusinessUnit> BusinessUnits { get; }

        /// <summary>
        /// Gets the writable business units.
        /// </summary>
        /// <value>
        /// The writable business units.
        /// </value>
        IList<IWritableBusinessUnit> WritableBusinessUnits { get; }

        /// <summary>
        /// Gets the readonly business units.
        /// </summary>
        /// <value>
        /// The readonly business units.
        /// </value>
        IList<IReadonlyBusinessUnit> ReadonlyBusinessUnits { get; }
    }
}
