namespace SSH.Framework.CQRS
{
    public interface IBusinessUnit
    {
        string Name { get; }
        IApplicationModule ApplicationModule { get; }
    }
}
