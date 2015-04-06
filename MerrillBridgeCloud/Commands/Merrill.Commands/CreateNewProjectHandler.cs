// ***********************************************************************
// Assembly         : Merrill.Commands
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="CreateNewProjectHandler.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the CreateNewProjectHandler type.</summary>
// ***********************************************************************

namespace Merrill.Commands
{
    using Merrill.Infrastructure.Messaging;

    /// <summary>
    /// The create new project handler.
    /// </summary>
    public class CreateNewProjectHandler : ICommandHandler<CreateNewProjectCommand>
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        public void Execute(CreateNewProjectCommand command)
        {

        }
    }
}
