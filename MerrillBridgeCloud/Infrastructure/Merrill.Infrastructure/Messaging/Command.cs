// ***********************************************************************
// Assembly         : Merrill.Infrastructure
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="Command.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the Command type.</summary>
// ***********************************************************************

namespace Merrill.Infrastructure.Messaging
{
    using System;

    /// <summary>
    /// The command.
    /// </summary>
    [Serializable]
    public class Command : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="version">The version.</param>
        public Command(Guid id, int version)
        {
            this.Id = id;
            this.Version = version;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public int Version { get; private set; }
    }
}
