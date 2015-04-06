

namespace Merrill.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    using Microsoft.Azure;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    /// <summary>
    /// Implements an asynchronous sender of messages to a Windows Azure Service Bus topic.
    /// </summary>
    public class MessageSender : IMessageSender
    {

        private TopicClient Client;
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicSender"/> class, 
        /// automatically creating the given topic if it does not exist.
        /// </summary>
        public MessageSender(string connectionString)
        {

            Client = TopicClient.CreateFromConnectionString(connectionString, "Project");

        }
        public void Send(BrokeredMessage messageFactory)
        {


            Client.Send(messageFactory);
        }
    }
}
