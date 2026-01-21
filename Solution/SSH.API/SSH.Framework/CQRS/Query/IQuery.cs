namespace SSH.Framework.CQRS
{
    public interface IQuery
    {
        Guid QueryID { get; }
        DateTime ExecutingBeingAt { get; }
        DateTime? ExecutingEndAt { get; }
    }

    public interface IQuery<TResult> : IQuery
    {
        TResult ExecutionResult { get; set; }
    }

    public interface IQuery<TResult, TInput> : IQuery<TResult>
    {
        TInput QueryParameter { get; set; }
    }
}

