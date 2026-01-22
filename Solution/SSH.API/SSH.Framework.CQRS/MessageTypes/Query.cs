using SSH.Framework.CQRS.SharedModels;

namespace SSH.Framework.CQRS.Impl
{
    public class Query : IQuery
    {
        public Query()
        {
            QueryID = Guid.NewGuid();
            ExecutingBeingAt = DateTime.Now;
        }

        public Guid QueryID { get; private set; }

        public DateTime ExecutingBeingAt { get; set; }

        public DateTime? ExecutingEndAt { get; set; }
    }

    public class Query<TResult> : Query, IQuery<TResult>
    {
        public TResult ExecutionResult { get; set; }
    }

    public class Query<TResult, TInput> : Query<TResult>, IQuery<TResult, TInput>
    {
        public TInput QueryParameter { get; set; }
    }

    public class QueryEx<TResult> : Query<ServiceResult<TResult>>
    {
    }

    public class QueryEx<TResult, TInput> : Query<ServiceResult<TResult>, TInput>
    {
    }
}
