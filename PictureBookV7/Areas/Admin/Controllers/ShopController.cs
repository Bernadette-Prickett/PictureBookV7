﻿using PagedList;
using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Pages.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        [HttpGet]
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

        // Post: Admin/Shop/AddProduct
        [HttpPost]
        public ActionResult AddProduct(ProductVM model, HttpPostedFileBase file)
        {
            //Check model state
            if(! ModelState.IsValid)
            {
                using (Db db = new Db())
                {
                    model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                    return View(model);
                }
                    
            }

            //Ensure product name is unique
            using (Db db = new Db())
            {
                if(db.Products.Any( x => x.Name == model.Name))
                {
                    model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                    ModelState.AddModelError("", "That product name is already being used");
                    return View();
                }
            }

            //Declare product id
            int id;

            //Initialise and save productDTO
            using (Db db = new Db())
            {
                ProductDTO product = new ProductDTO();

                product.Name = model.Name;
                product.Slug = model.Name.Replace(" ", "-").ToLower();
                product.Description = model.Description;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;

                CategoryDTO catDTO = db.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
                product.CategoryName = catDTO.Name;

                db.Products.Add(product);
                db.SaveChanges();

                //get insert id               
                id = product.Id;
            }

            //Set TempData message
            TempData["SuccessMessage"] = "A new product has been added successfully";

            #region Upload Image

            //Create directories
            var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));

            var pathString1 = Path.Combine(originalDirectory.ToString(), "Products");
            var pathString2 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString());
            var pathString3 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Thumbs");
            var pathString4 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery");
            var pathString5 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery\\Thumbs");

            if (!Directory.Exists(pathString1))
                Directory.CreateDirectory(pathString1);

            if (!Directory.Exists(pathString2))
                Directory.CreateDirectory(pathString2);

            if (!Directory.Exists(pathString3))
                Directory.CreateDirectory(pathString3);

            if (!Directory.Exists(pathString4))
                Directory.CreateDirectory(pathString4);

            if (!Directory.Exists(pathString5))
                Directory.CreateDirectory(pathString5);

            //Check if a file was uploaded
            if(file != null && file.ContentLength > 0)
            {

                // Get the file extension
                string extension = file.ContentType.ToLower();

                //Verify extension
                if(extension != "image/jpg" && extension != "image/jpeg" &&
                    extension != "image/pjpeg" && extension != "image/gif" &&
                    extension != "image/x-png" && extension != "image/png" )
                {
                    using (Db db = new Db())
                    {
                        model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                        ModelState.AddModelError("", "That product name already exists");
                        return View(model);
                    }
                }

                //Initialise the image name
                string imageName = file.FileName;

                //Save image name to DTO
                using (Db db = new Db())
                {
                    ProductDTO dto = db.Products.Find(id);
                    dto.ImageName = imageName;

                    db.SaveChanges();
                }

                //Set original and thumbnail image paths
                var path = string.Format("{0}\\{1}", pathString2, imageName);
                var path2 = string.Format("{0}\\{1}", pathString3, imageName);

                //Save original
                file.SaveAs(path);

                //Create and save thumbnail
                WebImage img = new WebImage(file.InputStream);
                img.Resize(150, 200);
                img.Save(path2);
            }

            #endregion

            //Redirect
            return RedirectToAction("AddProduct");
        }

        // GET: Admin/Shop/Products
        public ActionResult Products(int? page, int? catId)
        {

            //Declare a list of ProductVM
            List<ProductVM> listOfProductVM;

            //Set page number
            var pageNumber = page ?? 1;
            using (Db db = new Db())
            {
                //Initialise list
                listOfProductVM = db.Products.ToArray().Where(x => catId == null || catId == 0 || x.CategoryId == catId)
                    .Select(x => new ProductVM(x))
                    .ToList();

                //Populate categories select list
                ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");

                //Set selected category
                ViewBag.SelectedCat = catId.ToString();
            }

            //Set pagination
            var onePageOfProducts = listOfProductVM.ToPagedList(pageNumber, 5);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            //Return view with list
            return View(listOfProductVM);
        }

        // GET: Admin/Shop/EditProduct/id
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            //Declare ProductVM
            ProductVM model;

            using (Db db = new Db())
            {
                //Get the product
                ProductDTO dto = db.Products.Find(id);

                //Ensure product exists
                if(dto == null)
                {
                    return Content("The product does not exist");                
                }

                //Initialise model
                model = new ProductVM(dto);

                //Make select list
                model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");

                //Get all gallery images
                model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs")).Select(fn => Path.GetFileName(fn));
            }

            //Return view with model
            return View(model);
        }

        // Post: Admin/Shop/EditProduct/id
        [HttpPost]
        public ActionResult EditProductid(ProductVM model, HttpPostedFileBase file)
        {
            //Get product id
            int id = model.Id;

            //Populate categories select list and gallery images
            using (Db db = new Db())
            {
                model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }
            //Get all gallery images
            model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs")).Select(fn => Path.GetFileName(fn));

            //Check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Make sure product name isn't being used
            using (Db db = new Db())
            {
                if(db.Products.Where(x => x.Id != id).Any(x => x.Name == model.Name))
                {
                    ModelState.AddModelError("", "The product name has already been taken");
                    return View(model);
                }
            }

            //Update product
            using (Db db = new Db())
            {
                ProductDTO dto = db.Products.Find(id);

                dto.Name = model.Name;
                dto.Slug = model.Name.Replace(" ", "-").ToLower();
                dto.Price = model.Price;
                dto.Description = model.Description;
                dto.CategoryId = model.CategoryId;
                dto.ImageName = model.ImageName;

                CategoryDTO catDTO = db.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
                dto.CategoryName = catDTO.Name;

                db.SaveChanges();
            }

            //Set TempData message
            TempData["SuccessMessage"] = "Product has been edited successfully";

            #region Image Upload

            #endregion

            //Redirect
            return RedirectToAction("EditProduct");
           
        }

        // GET: Admin/Shop/DeleteProduct/id
        public ActionResult DeleteProduct(int id)        
        {
            using (Db db = new Db())
            {
                //Get the product
                ProductDTO dto = db.Products.Find(id);

                //Delete the product
                db.Products.Remove(dto);


                //For some reason this is causing a problem
                //Flag the category as deleted rather than actually delete the data as this can mess up reports
                //dto.Deleted = true;

                //Save
                db.SaveChanges();
            }

            //Redirect
            return RedirectToAction("Products");
        }

        // Post: Admin/Shop/SaveGalleryImages
        [HttpPost]
        public ActionResult SaveGalleryImages(int id)
        {
            //Loop through the files
            foreach (string fileName in Request.Files)
            {
                //Initialise the file
                HttpPostedFileBase file = Request.Files[fileName];

                //Check that is not null
                if (file != null && file.ContentLength > 0)
                {
                    //Set the directory paths
                    var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));

                    string pathString1 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery");
                    string pathString2 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery\\Thumbs");

                    //Set the image paths
                    var path = string.Format("{0}\\{1}", pathString1, file.FileName);
                    var path2 = string.Format("{0}\\{1}", pathString2, file.FileName);

                    //Save original and thumb
                    file.SaveAs(path);
                    WebImage img = new WebImage(file.InputStream);
                    img.Resize(150, 200);
                    img.Save(path2);
                }
            }
            return View();
        }

    }
}