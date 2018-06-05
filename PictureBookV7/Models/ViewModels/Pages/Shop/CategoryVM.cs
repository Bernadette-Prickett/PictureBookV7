using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.ViewModels.Pages.Shop
{
    public class CategoryVM
    {
        //Getters and Setters
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "URL")]
        public string Slug { get; set; }
        public int Sorting { get; set; }

        //Empty Constructor
        public CategoryVM()
        {

        }

        //Overloaded Constructor
        public CategoryVM(CategoryDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Slug = row.Slug;
            Sorting = row.Sorting;
        }
    }
}