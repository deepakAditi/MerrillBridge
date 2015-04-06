

namespace Merrill.Infrastructure.Messaging
{
    using System;
   using Microsoft.ServiceBus.Messaging;

    /// <summary>
    /// Abstracts the behavior of sending a message.
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Sends the specified message synchronously.
        /// </summary>
        void Send(BrokeredMessage messageFactory);

    

    }
}
