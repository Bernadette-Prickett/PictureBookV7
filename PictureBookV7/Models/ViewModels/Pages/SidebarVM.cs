using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.ViewModels.Pages
{
    public class SidebarVM
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public SidebarVM()
        {

        }

        public SidebarVM(SidebarDTO row)
        {
            Id = row.Id;
            Body = row.Body;
        }
    }
}