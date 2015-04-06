using System;


namespace Merrill.Infrastructure.Messaging
{
    using System.Collections.Generic;

    using Merrill.Infrastructure.Messaging;

    public interface ICommandBus
    {
        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commands">The commands.</param>
        void Send<T>(IEnumerable<Envelope<T>> commands) where T : Command;

        /// <summary>
        /// Sends the asyncc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        void Send<T>(Envelope<T> command) where T : Command;
    }
}
