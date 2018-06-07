// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-01-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-05-2018
// ***********************************************************************
// <copyright file="PageVM.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Models.ViewModels.Pages
{
    /// <summary>
    /// Class PageVM.
    /// </summary>
    public class PageVM
    {
        //Empty Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PageVM"/> class.
        /// </summary>
        public PageVM()
        {                            
        }

        //Overloaded Constructor that takes the PageDTO as a parameter
        /// <summary>
        /// Initializes a new instance of the <see cref="PageVM"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public PageVM(PageDTO row)
        {
            Id = row.Id;
            Title = row.Title;
            Slug = row.Slug;
            Body = row.Body;
            Sorting = row.Sorting;
            HasSidebar = row.HasSidebar;
        }

        //Getters and Setters + added Data Annotations to specify if properties are required and their minimum/maximum length
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>The slug.</value>
        [Display(Name ="URL")]
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        [AllowHtml]
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