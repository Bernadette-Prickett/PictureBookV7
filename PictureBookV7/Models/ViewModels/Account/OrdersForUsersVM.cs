// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-07-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="OrdersForUsersVM.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.ViewModels.Account
{
    /// <summary>
    /// Class OrdersForUsersVM.
    /// </summary>
    public class OrdersForUsersVM
    {
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>The order number.</value>
        public int OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public decimal Total { get; set; }
        /// <summary>
        /// Gets or sets the products and qty.
        /// </summary>
        /// <value>The products and qty.</value>
        public Dictionary<string, int> ProductsAndQty { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }
    }
}