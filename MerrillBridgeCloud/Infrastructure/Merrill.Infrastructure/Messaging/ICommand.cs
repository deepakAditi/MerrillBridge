using System;

namespace Merrill.Infrastructure.Messaging
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
