// ***********************************************************************
// Assembly         : Merrill.Infrastructure
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="Converter.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>The converter.</summary>
// ***********************************************************************

namespace Merrill.Infrastructure.Messaging
{
    using System;

    /// <summary>
    /// The converter.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="myActionT">
        /// The my action t.
        /// </param>
        /// <typeparam name="T">
        /// action
        /// </typeparam>
        /// <returns>
        /// The <see cref="Action"/>.
        /// </returns>
        public static Action<object> Convert<T>(Action<T> myActionT)
        {
            if (myActionT == null)
            {
                return null;
            }

            return o => myActionT((T)o);
        }

        /// <summary>
        /// The change to.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="dest">
        /// The destination.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>dynamic</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static dynamic ChangeTo(dynamic source, Type dest)
        {
            return System.Convert.ChangeType(source, dest);
        }
    }
}
