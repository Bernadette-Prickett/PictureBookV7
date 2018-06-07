// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-07-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="OrderDetailsDTO.cs" company="">
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
    /// Class OrderDetailsDTO.
    /// </summary>
    [Table("tbl_OrderDetails")]
    public class OrderDetailsDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public int ProductId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        [ForeignKey("OrderId")]
        public virtual OrderDTO Orders { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        [ForeignKey("UserId")]
        public virtual UserDTO Users { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        [ForeignKey("ProductId")]
        public virtual ProductDTO Products { get; set; }
    }
}