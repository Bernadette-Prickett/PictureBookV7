// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-06-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="PagesController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    /// <summary>
    /// Class PagesController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class PagesController : Controller
    {
        // GET: Index/{page}
        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>ActionResult.</returns>
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

        /// <summary>
        /// Pageses the menu partial.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult PagesMenuPartial()
        {
            //Declare a list of PageVM
            List<PageVM> pageVMList;

            //Get all pages with the exception of home
            using (Db db = new Db())
            {
                pageVMList = db.Pages.ToArray().OrderBy(x => x.Sorting).Where(x => x.Slug != "home").Select(x => new PageVM(x)).ToList();
            }

            //Return partial view with list
            return PartialView(pageVMList);
        }

        /// <summary>
        /// Sidebars the partial.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult SidebarPartial()
        {

            //Declare model
            SidebarVM model;

            //Initialise model
            using (Db db = new Db())
            {
                SidebarDTO dto = db.Sidebar.Find(1);

                model = new SidebarVM(dto);
            }

            //Return partial view with model
            return PartialView(model);
        }
    }
}