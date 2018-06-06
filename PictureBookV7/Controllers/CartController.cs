using PictureBookV7.Models.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            //Initialise the cart list
            var cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            //Check if cart is empy
            if (cart.Count == 0 || Session["cart"] == null)
            {
                ViewBag.Message = "Your cart is empty. Why not add something";
                return View();
            }

            //Calculate total and save to ViewBag
            decimal total = 0m;

            foreach (var item in cart)
            {
                total += item.Total;
            }

            ViewBag.GrandTotal = total;

            //Return view with list
            return View(cart);
        }

        public ActionResult CartPartial()
        {
            //Initialise CartVM
            CartVM model = new CartVM();

            //Initialise quantity
            int qty = 0;

            //Initialise price
            decimal price = 0m;

            //Check for cart session
            if (Session["cart"] != null)
            {
                //Get total for quantity and price
                var list = (List<CartVM>) Session["cart"];

                foreach (var item in list)
                {
                    qty += item.Quantity;
                    price += item.Quantity * item.Price;
                }
            }
            else
            {
                //Or set quantity and price to 0
                model.Quantity = 0;
                model.Price = 0m;
            }

            

            

            //Return partial view with model
            return PartialView(model);
        }
    }
}