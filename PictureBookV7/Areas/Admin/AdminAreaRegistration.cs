// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-01-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-01-2018
// ***********************************************************************
// <copyright file="AdminAreaRegistration.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Mvc;

namespace PictureBookV7.Areas.Admin
{
    /// <summary>
    /// Class AdminAreaRegistration.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    public class AdminAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <value>The name of the area.</value>
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}