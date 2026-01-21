
namespace SSH.Framework.CQRS
{
    public class ReadonlyBusinessUnit : BusinessUnit, IReadonlyBusinessUnit
    {
        protected ReadonlyBusinessUnit(IApplicationModule applicationModule) : base(applicationModule)
        {
            QueryMap = new Dictionary<Type, Type>();
        }

        public IDictionary<Type, Type> QueryMap { get; private set; }

        public void RegisterQuery<TQuery, TExecutor>()
            where TQuery : IQuery
            where TExecutor : IQueryExecutor
        {
            QueryMap.Add(typeof(TQuery), typeof(TExecutor));
        }
    }
}
