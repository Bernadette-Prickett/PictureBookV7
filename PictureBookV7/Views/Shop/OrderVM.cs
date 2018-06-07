// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-07-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="OrderVM.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureBookV7.Views.Shop
{
    /// <summary>
    /// Class OrderVM.
    /// </summary>
    public class OrderVM
    {
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
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderVM"/> class.
        /// </summary>
        public OrderVM()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderVM"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public OrderVM(OrderDTO row)
        {
            OrderId = row.OrderId;
            UserId = row.UserId;
            DateCreated = row.DateCreated;
        }
    }
}