// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-05-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-05-2018
// ***********************************************************************
// <copyright file="SidebarDTO.cs" company="">
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
    /// Class SidebarDTO.
    /// </summary>
    [Table("tbl_Sidebar")]
    public class SidebarDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }
    }
}