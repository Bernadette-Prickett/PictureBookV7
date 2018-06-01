using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            //Declare a list of PageVM
            List<PageVM> pagesList;

            
            using (Db db = new Db())
            {
                //Initialise the list
                pagesList = db.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
            }

            //Return a view with list
            return View(pagesList);
        }
    }
}