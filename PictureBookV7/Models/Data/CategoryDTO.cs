// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-05-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CategoryDTO.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.Data
{
    /// <summary>
    /// Class CategoryDTO.
    /// </summary>
    [Table("tbl_Categories")]
    public class CategoryDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>The slug.</value>
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        /// <value>The sorting.</value>
        public int Sorting { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CategoryDTO"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted { get; set; }
    }
}