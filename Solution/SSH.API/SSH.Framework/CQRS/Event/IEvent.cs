using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.CQRS
{
    public interface IEvent : IMessage
    {
    }

    public interface IEvent<TArg> : IEvent
    {
        TArg EventArgument { get; set; }
    }
}
