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
            return View();
        }

        // GET: Account/Create-Account
        [ActionName("Create-Account")]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }
    }
}