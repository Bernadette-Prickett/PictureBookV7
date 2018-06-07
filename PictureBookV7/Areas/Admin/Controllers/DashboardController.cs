// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-01-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="DashboardController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Areas.Admin.Controllers
{
    /// <summary>
    /// Class DashboardController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}