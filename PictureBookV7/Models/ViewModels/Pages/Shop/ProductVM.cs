using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Models.ViewModels.Pages.Shop
{
    public class ProductVM
    {
        //Getters and Setters
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="URL")]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string ImageName { get; set; }

        //This selectlistitem will be used when adding a product and choosing it's category
        public IEnumerable<SelectListItem> Categories { get; set; }
        //A gallery of images will also be needed
        public IEnumerable<string> GalleryImages { get; set; }

        //Empty Constructor
        public ProductVM()
        {

        }

        //Overloaded constructor
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