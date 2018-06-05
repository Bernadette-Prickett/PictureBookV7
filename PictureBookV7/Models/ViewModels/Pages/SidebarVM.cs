using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Models.ViewModels.Pages
{
    public class SidebarVM
    {
        //Getters and Setters + Data Annotations
        public int Id { get; set; }
        [AllowHtml]
        public string Body { get; set; }

        //Empty Constructor
        public SidebarVM()
        {

        }

        //Overloaded Constructor
        public SidebarVM(SidebarDTO row)
        {
            Id = row.Id;
            Body = row.Body;
        }


    }
}