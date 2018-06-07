// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-06-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ProductVM.cs" company="">
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

namespace PictureBookV7.Models.ViewModels.Pages.Shop
{
    /// <summary>
    /// Class ProductVM.
    /// </summary>
    public class ProductVM
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
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>The slug.</value>
        [Display(Name ="URL")]
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        public string CategoryName { get; set; }
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        [Required]
        public int CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <value>The name of the image.</value>
        public string ImageName { get; set; }

        //This selectlistitem will be used when adding a product and choosing it's category
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public IEnumerable<SelectListItem> Categories { get; set; }
        //A gallery of images will also be needed
        /// <summary>
        /// Gets or sets the gallery images.
        /// </summary>
        /// <value>The gallery images.</value>
        public IEnumerable<string> GalleryImages { get; set; }

        //Empty Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductVM"/> class.
        /// </summary>
        public ProductVM()
        {

        }

        //Overloaded constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductVM"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public ProductVM(ProductDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Slug = row.Slug;
            Description = row.Description;
            Price = row.Price;
            CategoryName = row.CategoryName;
            CategoryId = row.CategoryId;
            ImageName = row.ImageName;
        }
    }
}