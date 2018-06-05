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
                //Initialise the list
                categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }

                //Return view with a list
                return View(categoryVMList);
        }
    }
}