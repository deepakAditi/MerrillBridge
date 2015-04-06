// ***********************************************************************
// Assembly         : Merrill.Commands
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="CreateNewProjectCommand.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the CreateNewProjectCommand type.</summary>
// ***********************************************************************

namespace Merrill.Commands
{
    using System;

    using Merrill.Infrastructure.Messaging;

    /// <summary>
    /// Class CreateNewProjectCommand.
    /// </summary>
    public class CreateNewProjectCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewProjectCommand"/> class.
        /// </summary>
        /// <param name="aggregateId">
        /// The aggregate id.
        /// </param>
        /// <param name="projectTypeId">
        /// The project type id.
        /// </param>
        /// <param name="edgar">
        /// The edgar.
        /// </param>
        /// <param name="xbrl">
        /// The xbrl Tag.
        /// </param>
        /// <param name="styling">
        /// The styling.
        /// </param>
        /// <param name="exhibits">
        /// The exhibits.
        /// </param>
        /// <param name="needBy">
        /// The need by.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="emailNotification">
        /// The email notification.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        public CreateNewProjectCommand(
            Guid aggregateId,
            int projectTypeId,
            bool edgar,
            bool xbrl,
            bool styling,
            bool exhibits,
            DateTime needBy,
            string description,
            bool emailNotification,
            int version)
            : base(aggregateId, version)
        {
            this.ProjectTypeId = projectTypeId;
            this.Edgar = edgar;
            this.Xbrl = xbrl;
            this.Styling = styling;
            this.Exhibits = exhibits;
            this.NeedBy = needBy;
            this.Description = description;
            this.EmailNotification = emailNotification;
        }

        /// <summary>
        /// Gets or sets the project type id.
        /// </summary>
        public int ProjectTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreateNewProjectCommand"/> is edgar.
        /// </summary>
        /// <value><c>true</c> if edgar; otherwise, <c>false</c>.</value>
        public bool Edgar { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreateNewProjectCommand"/> is XBRL.
        /// </summary>
        /// <value><c>true</c> if XBRL; otherwise, <c>false</c>.</value>
        public bool Xbrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreateNewProjectCommand"/> is styling.
        /// </summary>
        /// <value><c>true</c> if styling; otherwise, <c>false</c>.</value>
        public bool Styling { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether exhibits.
        /// </summary>
        public bool Exhibits { get; set; }

        /// <summary>
        /// Gets or sets the need by.
        /// </summary>
        /// <value>The need by.</value>
        public DateTime NeedBy { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [email notification].
        /// </summary>
        /// <value><c>true</c> if [email notification]; otherwise, <c>false</c>.</value>
        public bool EmailNotification { get; set; }
    }
}
