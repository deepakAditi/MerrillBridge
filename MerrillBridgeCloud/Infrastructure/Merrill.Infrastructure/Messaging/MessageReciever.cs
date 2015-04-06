// ***********************************************************************
// Assembly         : Merrill.Infrastructure
// Author           : Deepakkumar G
// Created          : 04-02-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 04-03-2015
// ***********************************************************************
// <copyright file="MessageReciever.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the MessageReciever type.</summary>
// ***********************************************************************

namespace Merrill.Infrastructure.Messaging
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    using Microsoft.ServiceBus.Messaging;

    /// <summary>
    /// The message reciever.
    /// </summary>
    public class MessageReciever : IMessageReciever
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string connectionString;

        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly ITextSerializer serializer;

        /// <summary>
        /// The command handler factory.
        /// </summary>
        private readonly ICommandHandlerFactory commandHandlerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReciever"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <param name="commandHandlerFactory">
        /// The command handler factory.
        /// </param>
        public MessageReciever(string connectionString, ITextSerializer serializer, ICommandHandlerFactory commandHandlerFactory)
        {
            this.connectionString = connectionString;
            this.serializer = serializer;
            this.commandHandlerFactory = commandHandlerFactory;
            Task task = new Task(new Action(ReceiveMessage));
            task.Start();
        }

        /// <summary>
        /// The receive message.
        /// </summary>
        public void ReceiveMessage()
        {
            SubscriptionClient client = SubscriptionClient.CreateFromConnectionString(
                this.connectionString,
                "Project",
                "NewProject");

            // Configure the callback options
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            client.OnMessage(
                message =>
                    {
                        try
                        {
                            dynamic payload;
                    using (var stream = message.GetBody<Stream>())
                    using (var reader = new StreamReader(stream))
                    {
                        try
                        {
                            payload = this.serializer.Deserialize(reader);
                            this.HandleCommand(payload);
                        }
                        catch (SerializationException)
                        {
                        }
                    }

                    message.Complete();
                }
                        catch (Exception)
                        {
                            message.Abandon();
                        }
                    },
                options);
        }

        /// <summary>
        /// The handle command.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        private void HandleCommand<T>(T command) where T : Command
        {
            var handler = this.commandHandlerFactory.GetHandler<T>();
            if (handler != null)
            {
                handler.Execute(command);
            }
        }        
    }
}
