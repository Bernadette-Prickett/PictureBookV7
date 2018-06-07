// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-06-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CartVM.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.ViewModels.Cart
{
    /// <summary>
    /// Class CartVM.
    /// </summary>
    public class CartVM
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public int ProductId { get; set; }
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <value>The total.</value>
        public decimal Total { get { return Quantity * Price; } }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public string Image { get; set; }
    }
}