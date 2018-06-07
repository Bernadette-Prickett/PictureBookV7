// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-01-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="Db.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.Data
{
    /// <summary>
    /// Class Db.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class Db : DbContext
    {
        //This will allow me to access tables through EntityFramework
        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>The pages.</value>
        public DbSet<PageDTO> Pages { get; set; }
        /// <summary>
        /// Gets or sets the sidebar.
        /// </summary>
        /// <value>The sidebar.</value>
        public DbSet<SidebarDTO> Sidebar { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public DbSet<CategoryDTO> Categories { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public DbSet<ProductDTO> Products { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<UserDTO> Users { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public DbSet<RoleDTO> Roles { get; set; }
        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        /// <value>The user roles.</value>
        public DbSet<UserRoleDTO> UserRoles { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public DbSet<OrderDTO> Orders { get; set; }
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public DbSet<OrderDetailsDTO> OrderDetails { get; set; }
    }
}