using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Areas.Admin.Controllers
{
    public class ShopController : Controller
    {
        // GET: Admin/Shop/Categories        
        public ActionResult Categories()
        {
            //Declare a list of models
            List<CategoryVM> categoryVMList;

            using (Db db = new Db())
            {
                //Initialise the list - 
                //The .Where(x => !x.Deleted) only pulls back rows with Deleted = false                
                categoryVMList = db.Categories.Where(x => !x.Deleted).ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }

            //Return view with a list
            return View(categoryVMList);
        }

        // Post: Admin/Shop/AddNewCategory
        [HttpPost]
        public string AddNewCategory(string catName)
        {
            //Declare id
            string id;

            using (Db db = new Db())
            {

                //Check that the category name hasn't been taken
                if(db.Categories.Any(x => x.Name == catName))
                    return "titletaken";                         
                    

                //Initialise the DTO
                CategoryDTO dto = new CategoryDTO();

                //Add to the DTO
                dto.Name = catName;
                dto.Slug = catName.Replace(" ", "-").ToLower();
                dto.Sorting = 100;

                //Save DTO
                db.Categories.Add(dto);
                db.SaveChanges();

                //Get the id
                id = dto.Id.ToString();
            }

            //Return id
            return id;
        }

        // Get Admin/Shop/DeleteCategory/id
        public ActionResult DeleteCategory(int id)
        {
            using (Db db = new Db())
            {
                //Get the page
                CategoryDTO dto = db.Categories.Find(id);

                //Flag the category as deleted rather than actually delete the data as this can mess up reports
                dto.Deleted = true;

                //Save
                db.SaveChanges();
            }

            //Redirect
            return RedirectToAction("Categories");
        }

        // Post: Admin/Shop/RenameCategory
        [HttpPost]
        public string RenameCategory(string newCatName, int id)
        {
            using (Db db = new Db())
            {
                //Check category name hasn't already been taken
                if (db.Categories.Any(x => x.Name == newCatName))
                    return "titletaken";

                //Get DTO
                CategoryDTO dto = db.Categories.Find(id);

                //Edit DTO
                dto.Name = newCatName;
                dto.Slug = newCatName.Replace(" ", "-").ToLower();

                //Save
                db.SaveChanges();
            }

            //Return
            return "Okay";
        }

        // GET: Admin/Shop/AddProduct
        public ActionResult AddProduct()
        {
            //Initialise model
            ProductVM model = new ProductVM();

            //Add select list of categories to model
            using (Db db = new Db())
            {
                model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }

            //Return view with model
            return View(model);
        }
    }
}