namespace SSH.Framework.CQRS
{
    public interface IQueryExecutor
    {

    }

    public interface IQueryExecutor<in TQuery, TResult> : IQueryExecutor where TQuery : IQuery<TResult>
    {
        Task<TResult> Execute(TQuery query);
    }

    public interface IQueryExecutor<in TQuery, TResult, TInput> : IQueryExecutor where TQuery : IQuery<TResult, TInput>
    {

    }
}
