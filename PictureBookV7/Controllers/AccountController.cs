using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return Redirect("~/Account/Login");
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            //Confirm user is not logged in
            string username = User.Identity.Name;

            if (!string.IsNullOrEmpty(username))
                return RedirectToAction("User-Profile");

            //Return view
            return View();
        }

        // GET: Account/Create-Account
        [ActionName("Create-Account")]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }

        // POST: Account/Create-Account
        [ActionName("Create-Account")]
        [HttpPost]
        public ActionResult CreateAccount(UserVM model)
        {
            //Check model state
            if (!ModelState.IsValid)
            {
                return View("CreateAccount", model);
            }

            //Check if passwords match
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View("CreateAccount", model);
            }

            using (Db db = new Db())
            {
                //Make sure username is unique
                if (db.Users.Any(x => x.Username.Equals(model.Username)))
                {
                    ModelState.AddModelError("", "Username " + model.Username + " is taken. Please enter a different username");
                    model.Username = "";
                    return View("CreateAccount", model);
                }

                //Create userDTO
                UserDTO userDTO = new UserDTO()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    Username = model.Username,
                    Password = model.Password
                };

                //Add the DTO
                db.Users.Add(userDTO);

                //Save
                db.SaveChanges();

                //Add to UserRolesDTO
                int id = userDTO.Id;

                UserRoleDTO userRolesDTO = new UserRoleDTO()
                {
                    UserId = id,
                    RoleId = 2
                };

                db.UserRoles.Add(userRolesDTO);
                db.SaveChanges();
            }

            //Create a TempData message
            TempData["SuccessMessage"] = "Registration Successful";

            //Redirect
            return Redirect("~/Account/Login");
        }

    }
}