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
        [HttpGet]
        public ActionResult Categories()
        {
            //Declare a list of models
            List<CategoryVM> categoryVMList;

            using (Db db = new Db())
            {
                //Initialise the list
                categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }

                //Return view with a list
                return View(categoryVMList);
        }

        // Post: Admin/Shop/Categories
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
    }
}