// ***********************************************************************
// Assembly         : Merrill.Infrastructure
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="CommandBus.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Merrill.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.Azure;
    using Microsoft.ServiceBus.Messaging;

    /// <summary>
    /// The command bus.
    /// </summary>
    public class CommandBus : ICommandBus
    {
        private readonly IMessageSender sender;

        private readonly IMetadataProvider metadataProvider;

        private readonly ITextSerializer serializer;

        /// <summary>
        /// The _command handler factory.
        /// </summary>
        private readonly ICommandHandlerFactory commandHandlerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBus"/> class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="metadataProvider">
        /// The metadata Provider.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>



        public CommandBus(IMessageSender sender, IMetadataProvider metadataProvider, ITextSerializer serializer)
        {
            this.sender = sender;
            this.metadataProvider = metadataProvider;
            this.serializer = serializer;
        
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <typeparam name="T">
        /// command
        /// </typeparam>
        public void Send<T>(Envelope<T> command) where T : Command
        {
            
            this.sender.Send(BuildMessage(command));
        }

        public void Send<T>(IEnumerable<Envelope<T>> commands) where T : Command
        {
            foreach (var command in commands)
            {
                this.Send(command);
            }
        }


        private BrokeredMessage BuildMessage<T>(Envelope<T> command) where T : Command
        {
            var stream = new MemoryStream();
            try
            {
                var writer = new StreamWriter(stream);
                this.serializer.Serialize(writer, command.Body);
                stream.Position = 0;

                var message = new BrokeredMessage(stream, true);

                if (!string.IsNullOrWhiteSpace(command.MessageId))
                {
                    message.MessageId = command.MessageId;
                }
                else if (!default(Guid).Equals(command.Body.Id))
                {
                    message.MessageId = command.Body.Id.ToString();
                }

                if (!string.IsNullOrWhiteSpace(command.CorrelationId))
                {
                    message.CorrelationId = command.CorrelationId;
                }

                var metadata = this.metadataProvider.GetMetadata(command.Body);
                if (metadata != null)
                {
                    foreach (var pair in metadata)
                    {
                        message.Properties[pair.Key] = pair.Value;
                    }
                }

                if (command.Delay > TimeSpan.Zero)
                {
                    message.ScheduledEnqueueTimeUtc = DateTime.UtcNow.Add(command.Delay);
                }

                if (command.TimeToLive > TimeSpan.Zero)
                {
                    message.TimeToLive = command.TimeToLive;
                }

                return message;
            }
            catch
            {
                stream.Dispose();
                throw;
            }
        }


    }
}
