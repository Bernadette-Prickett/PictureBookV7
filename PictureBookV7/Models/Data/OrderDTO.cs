// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-07-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="OrderDTO.cs" company="">
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
    /// Class OrderDTO.
    /// </summary>
    [Table("tbl_Orders")]
    public class OrderDTO
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        [ForeignKey("UserId")]
        public virtual UserDTO Users { get; set; }
    }
}