// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-01-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-01-2018
// ***********************************************************************
// <copyright file="PageDTO.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.Data
{
    /// <summary>
    /// Class PageDTO.
    /// </summary>
    [Table("tbl_Pages")]
    public class PageDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>The slug.</value>
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }
        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        /// <value>The sorting.</value>
        public int Sorting { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has sidebar.
        /// </summary>
        /// <value><c>true</c> if this instance has sidebar; otherwise, <c>false</c>.</value>
        public bool HasSidebar { get; set; }
    }
}