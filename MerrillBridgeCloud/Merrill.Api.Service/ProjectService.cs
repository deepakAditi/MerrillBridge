// ***********************************************************************
// Assembly         : Merrill.Api.Service
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="ProjectService.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the ProjectService type.</summary>
// ***********************************************************************

namespace Merrill.Api.Service
{
    using System;

    using Merrill.Commands;
    using Merrill.Infrastructure.Messaging;

    /// <summary>
    /// The project service.
    /// </summary>
    public class ProjectService : IProjectService
    {
        /// <summary>
        /// The command bus.
        /// </summary>
        private readonly ICommandBus commandBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectService"/> class.
        /// </summary>
        /// <param name="commandBus">
        /// The command bus.
        /// </param>
        public ProjectService(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        public void Post(Contracts.Project project)
        {
            this.commandBus.Send<CreateNewProjectCommand>(new CreateNewProjectCommand(Guid.NewGuid(), project.ProjectTypeId, project.Edgar, project.Xbrl, project.Styling, project.Exhibits, project.NeedBy, project.Description, project.EmailNotification, 1));
        }
    }
}
