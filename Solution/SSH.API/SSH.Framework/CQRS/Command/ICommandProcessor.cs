using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.CQRS
{
    public interface ICommandProcessor : IMessageHandler { }

    public interface ICommandProcessor<in TCommand> : ICommandProcessor where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }

    public interface ICommandProcessor<in TCommand, in TInput> : ICommandProcessor where TCommand : ICommand<TInput>
    {
        Task Execute(TCommand command);
    }

    public interface ICommandProcessor<in TCommand, TResult, in TInput> : ICommandProcessor where TCommand : ICommand<TResult, TInput>
    {
        Task<TResult> Execute(TCommand command);
    }
}
