﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.Data
{
    [Table("tbl_Products")]
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal Price  { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
        //public bool Deleted { get; set; }

        [ForeignKey("CategoryId")]
        //In this instance virtual is used for lazy loading
        public virtual CategoryDTO Category { get; set; }
    }
}