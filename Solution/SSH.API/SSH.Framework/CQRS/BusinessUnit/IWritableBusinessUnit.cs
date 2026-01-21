namespace SSH.Framework.CQRS
{
    public interface IWritableBusinessUnit : IBusinessUnit
    {
        IDictionary<Type, Type> CommandMap { get; }

        IDictionary<Type, Type> EventMap { get; }
    }
}
