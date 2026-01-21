namespace SSH.Framework.CQRS
{
    public interface IReadonlyBusinessUnit : IBusinessUnit
    {
        IDictionary<Type, Type> QueryMap { get; }

        void RegisterQuery<TQuery, TExecutor>()
            where TQuery : IQuery
            where TExecutor : IQueryExecutor;
    }
}
