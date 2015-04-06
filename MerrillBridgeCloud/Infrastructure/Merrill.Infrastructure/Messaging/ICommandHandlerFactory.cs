using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Merrill.Infrastructure.Messaging
{

    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
