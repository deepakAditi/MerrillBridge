// ***********************************************************************
// Assembly         : Merrill.Domain
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="Project.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the Project type.</summary>
// ***********************************************************************

namespace Merrill.Domain
{
    using System;

   
    /// <summary>
    /// Class Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the project type id.
        /// </summary>
        public int ProjectTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Project"/> is edgar.
        /// </summary>
        /// <value><c>true</c> if edgar; otherwise, <c>false</c>.</value>
        public bool Edgar { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Project"/> is XBRL.
        /// </summary>
        /// <value><c>true</c> if XBRL; otherwise, <c>false</c>.</value>
        public bool Xbrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Project"/> is styling.
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
