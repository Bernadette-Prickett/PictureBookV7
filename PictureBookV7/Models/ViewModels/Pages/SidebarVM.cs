// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-05-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-05-2018
// ***********************************************************************
// <copyright file="SidebarVM.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Models.ViewModels.Pages
{
    /// <summary>
    /// Class SidebarVM.
    /// </summary>
    public class SidebarVM
    {
        //Getters and Setters + Data Annotations
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [AllowHtml]
        public string Body { get; set; }

        //Empty Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SidebarVM"/> class.
        /// </summary>
        public SidebarVM()
        {

        }

        //Overloaded Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SidebarVM"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public SidebarVM(SidebarDTO row)
        {
            Id = row.Id;
            Body = row.Body;
        }


    }
}