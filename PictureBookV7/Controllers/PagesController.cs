using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    public class PagesController : Controller
    {
        // GET: Index/{page}
        public ActionResult Index(string page = "")
        {
            //Get/Set page slug(url)
            if (page == "")            
                page = "home";

            //Declare model and DTO
            PageVM model;
            PageDTO dto;

            //Check if page exists
            using (Db db = new Db())
            {
                if (! db.Pages.Any(x => x.Slug.Equals(page)))
                {
                    return RedirectToAction("Index", new {page = ""});
                }
            }

            //Get page DTO
            using (Db db = new Db())
            {
                dto = db.Pages.Where(x => x.Slug == page).FirstOrDefault();
            }

            //Set page title
            ViewBag.PageTitle = dto.Title;

            //Check for sidebar
            if (dto.HasSidebar == true)
            {
                ViewBag.Sidebar = "Yes";
            }
            else
            {
                ViewBag.Sidebar = "No";
            }

            //Initialise model
            model = new PageVM(dto);

            //Return view with model
            return View(model);
        }
    }
}