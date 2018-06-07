// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-05-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-05-2018
// ***********************************************************************
// <copyright file="CategoryVM.cs" company="">
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

namespace PictureBookV7.Models.ViewModels.Pages.Shop
{
    /// <summary>
    /// Class CategoryVM.
    /// </summary>
    public class CategoryVM
    {
        //Getters and Setters
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
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
        [Display(Name = "URL")]
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        /// <value>The sorting.</value>
        public int Sorting { get; set; }

        //Empty Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryVM"/> class.
        /// </summary>
        public CategoryVM()
        {

        }

        //Overloaded Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryVM"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public CategoryVM(CategoryDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Slug = row.Slug;
            Sorting = row.Sorting;
        }
    }
}