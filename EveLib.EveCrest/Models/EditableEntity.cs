﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-28-2016
//
// Last Modified By : larsd
// Last Modified On : 03-01-2016
// ***********************************************************************
// <copyright file="EditableEntity.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    ///     Class EditableEntity.
    /// </summary>
    [DataContract]
    public class EditableEntity : IEditableEntity {

        /// <summary>
        ///     Gets or sets the eve crest.
        /// </summary>
        /// <value>The eve crest.</value>
        public EveCrest EveCrest { get; set; }

        /// <summary>
        /// Gets or sets the post URI.
        /// </summary>
        /// <value>The post URI.</value>
        public string PostUri { get; set; }

        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        /// <value>The href.</value>
        [DataMember(Name = "href")]
        public string Href { get; set; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="forcePostRequest">if set to <c>true</c> [force post request].</param>
        /// <returns>Task.</returns>
        public Task<bool> SaveAsync(bool forcePostRequest = false) {
            return EveCrest.SaveEntityAsync(this, forcePostRequest);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="forcePostRequest">if set to <c>true</c> [force post request].</param>
        /// <returns>System.Boolean.</returns>
        public bool Save(bool forcePostRequest = false) {
            return SaveAsync(forcePostRequest).Result;
        }

        /// <summary>
        ///     Deletes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public Task<bool> DeleteAsync() {
            return EveCrest.DeleteEntityAsync(this);
        }

        /// <summary>
        ///     Deletes this instance.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        public bool Delete() {
            return DeleteAsync().Result;
        }

        /// <summary>
        /// Shoulds the serialize href.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        public bool ShouldSerializeHref() => false;

    }
}