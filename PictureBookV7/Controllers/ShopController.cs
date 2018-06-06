using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
        }

        public ActionResult CategoryMenuPartial()
        {

            //Declare list of CatgegoryVM
            List<CategoryVM> categoryVMList;

            //Initialise the list
            using (Db db = new Db())
            {
                categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }
            
            //Return partial view with list                
            return PartialView(categoryVMList);
        }
    }
}