// ***********************************************************************
// Assembly         : MerrillBridgeService
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="ProjectController.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the ProjectController type.</summary>
// ***********************************************************************

namespace MerrillBridgeService.Controllers
{
    using System.Net.Http;
    using System.Web.Http;
    using Merrill.Api.Contracts;
    using Merrill.Api.Service;

    /// <summary>
    /// The project controller.
    /// </summary>
    public class ProjectController : ApiController
    {
        /// <summary>
        /// The project service.
        /// </summary>
        private readonly IProjectService projectService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="projectService">
        /// The project service.
        /// </param>
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [HttpPost]
        [Route("project")]
        public HttpResponseMessage Post(Project project)
        {
             try
             {
                 this.projectService.Post(project);
             }
             catch
             {
                  return null;
             }

            return null;
        }
    }
}
