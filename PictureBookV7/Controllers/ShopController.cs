// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-06-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ShopController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    /// <summary>
    /// Class ShopController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ShopController : Controller
    {
        // GET: Shop
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
        }

        /// <summary>
        /// Categories the menu partial.
        /// </summary>
        /// <returns>ActionResult.</returns>
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

        // GET: Shop/Category/Name
        /// <summary>
        /// Categories the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Category(string name)
        {
            //Declare a list of ProductVM
            List<ProductVM> productVMList;

            using (Db db = new Db())
            {
                //Get category id
                CategoryDTO categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
                int catId = categoryDTO.Id;

                //Initialise the list
                productVMList = db.Products.ToArray().Where(x => x.CategoryId == catId).Select(x => new ProductVM(x)).ToList();

                //Get category name
                var productCat = db.Products.Where(x => x.CategoryId == catId).FirstOrDefault();
                ViewBag.CategoryName = productCat.CategoryName;
            }

            //Return view with a list
            return View(productVMList);
        }

        // GET: Shop/Product-Details/Name
        /// <summary>
        /// Products the details.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ActionResult.</returns>
        [ActionName("Product-Details")]
        public ActionResult ProductDetails(string name)
        {
            //Declare VM and DTO
            ProductVM model;
            ProductDTO dto;

            //Initialise product id
            int id = 0;

            using (Db db = new Db())
            {
                //Check if product exists
                if (! db.Products.Any(x => x.Slug.Equals(name)))
                {
                    return RedirectToAction("Index");
                }

                //Initialise productDTO
                dto = db.Products.Where(x => x.Slug == name).FirstOrDefault();

                //Get insert id
                id = dto.Id;

                //Initialise model
                model = new ProductVM(dto);
            }

            //Get gallery images
            model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs")).Select(fn => Path.GetFileName(fn));

            //Return view with model
            return View("ProductDetails", model);
        }
    }
}