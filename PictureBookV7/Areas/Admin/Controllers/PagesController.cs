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

        // GET: Admin/Pages/AddPage
        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }

        // Post: Admin/Pages/AddPage
        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            //Check model state - This is the first thing you should do after submitting a form
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db = new Db())
            {

                //Declare slug
                string slug;

                //Initialise the DTO
                PageDTO dto = new PageDTO();

                //DTO title
                dto.Title = model.Title;

                //Check for and set slug
                if(string.IsNullOrWhiteSpace(model.Slug))
                {
                    slug = model.Title.Replace(" ", "-").ToLower();
                }
                else
                {
                    slug = model.Slug.Replace(" ", "-").ToLower();
                }

                //Ensure title and slug are unique
                if(db.Pages.Any(x => x.Title == model.Title) || db.Pages.Any(x => x.Slug == slug))
                {
                    ModelState.AddModelError("", "That title or slug already exists");
                    return View(model);
                }

                //DTO the rest
                dto.Slug = slug;
                dto.Body = model.Body;
                dto.HasSidebar = model.HasSidebar;
                //This will ensure that any new pages added will be the last page as this project will not have more than 100 pages
                dto.Sorting = 100;

                //Save DTO
                db.Pages.Add(dto);
                db.SaveChanges();

            }

            //Set TempData message - This is pretty much like a ViewBag but it persists after the next request
            TempData["SuccessMessage"] = "A new page has been added successfully";


                //Redirect
                return RedirectToAction("AddPage");
        }

        // GET: Admin/Pages/EditPage/id
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            //Declare pageVM
            PageVM model;

            using (Db db = new Db())
            {
                //Get the page - this will select the row with 'id' as the Primary key
                PageDTO dto = db.Pages.Find(id);

                //Confirm page exists
                if(dto == null)
                {
                    return Content("The page does not exist");
                }

                //Initialise the pageVM
                model = new PageVM(dto);
            }

                //Return view with model
                return View(model);
        }

        // Post: Admin/Pages/EditPage/id
        [HttpPost]
        public ActionResult EditPage(PageVM model)
        { 
            //Check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db = new Db())
            {

                //Get page id
                int id = model.Id;

                //Initialise the slug
                string slug = "home";

                //Get the page
                PageDTO dto = db.Pages.Find(id);

                //DTO the title
                dto.Title = model.Title;

                //Check for slug
                if(model.Slug != "home")
                {
                    if(string.IsNullOrWhiteSpace(model.Slug))
                    {
                        slug = model.Title.Replace(" ", "-").ToLower();
                    }
                    else
                    {
                        slug = model.Slug.Replace(" ", "-").ToLower();
                    }
                }

                //Make sure title and slug are unique
                if (db.Pages.Where(x => x.Id != id).Any(x => x.Title == model.Title) || db.Pages.Where(x => x.Id != id).Any(x => x.Slug == slug))
                {
                    ModelState.AddModelError("", "That title or slug already exists");
                }

                //DTO the rest
                dto.Slug = slug;
                dto.Body = model.Body;
                dto.HasSidebar = model.HasSidebar;

                //Save the DTO
                db.SaveChanges();

            }

            //Save the TempData message
            TempData["SuccessMessage"] = "The page has been edited successfully";

            //Return the view
            return RedirectToAction("EditPage");
        }

        // Get Admin/Pages/PageDetails/id        
        public ActionResult PageDetails(int id)
        {

            // Declare pageVM
            PageVM model;

            using (Db db = new Db())
            {
                //Get the page
                PageDTO dto = db.Pages.Find(id);

                //confirm page exists
                if(dto == null)
                {
                    return Content("The page does not exist");
                }

                //Initialise the page
                model = new PageVM(dto);

            }

            //Return view with model             
            return View(model);
        }

        // Get Admin/Pages/DeletePage/id
        public ActionResult DeletePage(int id)
        {
            using (Db db = new Db())
            {
                //Get the page
                PageDTO dto = db.Pages.Find(id);

                //Remove the page
                db.Pages.Remove(dto);

                //Save
                db.SaveChanges();
            }

            //Redirect
            return RedirectToAction("Index");
        }
    }
}