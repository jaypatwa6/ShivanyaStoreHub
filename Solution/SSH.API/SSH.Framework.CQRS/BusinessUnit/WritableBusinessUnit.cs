namespace SSH.Framework.CQRS
{
    public class WritableBusinessUnit : BusinessUnit, IWritableBusinessUnit
    {
        protected WritableBusinessUnit(IApplicationModule applicationModule) : base(applicationModule)
        {
            CommandMap = new Dictionary<Type, Type>();
            EventMap = new Dictionary<Type, Type>();
        }

        public IDictionary<Type, Type> CommandMap { get; private set; }

        public IDictionary<Type, Type> EventMap { get; private set; }

        protected   void RegisterCommand<TCommand, TProcessor>()
            where TCommand : ICommand
            where TProcessor : ICommandProcessor
        {
            CommandMap.Add(typeof(TCommand), typeof(TProcessor));
        }

        protected void RegisterEvent<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler
        {
            EventMap.Add(typeof(TEvent), typeof(THandler));
        }
    }
}
