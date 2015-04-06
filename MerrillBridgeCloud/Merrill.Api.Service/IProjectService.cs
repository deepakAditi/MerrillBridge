// ***********************************************************************
// Assembly         : Merrill.Api.Service
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="IProjectService.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the IProjectService type.</summary>
// ***********************************************************************

namespace Merrill.Api.Service
{
    using Merrill.Api.Contracts;

    /// <summary>
    /// The ProjectService interface.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        void Post(Project project);
    }
}
