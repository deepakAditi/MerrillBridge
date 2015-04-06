// ***********************************************************************
// Assembly         : Merrill.Infrastructure
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="CommandHandlerFactory.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>The structure map command handler factory.</summary>
// ***********************************************************************

namespace Merrill.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The structure map command handler factory.
    /// </summary>
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        /// <summary>
        /// The get handler.
        /// </summary>
        /// <typeparam name="T">
        /// handler
        /// </typeparam>
        /// <returns>
        /// ICommandHandler
        /// </returns>
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var container = new UnityContainer();
            var handlers = this.GetHandlerTypes<T>().ToList();
            return handlers.Select(ha => (ICommandHandler<T>)container.Resolve(ha)).FirstOrDefault();


        }

        /// <summary>
        /// The get handler types.
        /// </summary>
        /// <typeparam name="T">
        /// command
        /// </typeparam>
        /// <returns>
        /// IEnumerable
        /// </returns>
        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var types = AllClasses.FromLoadedAssemblies();
            var handlers = (from type in types
                            let implementedhandlerInterfaces = type.GetInterfaces()
                                 .Where(x => (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                            where implementedhandlerInterfaces.Any()
                            select type).ToList();

            return handlers;
        }
    }
}
