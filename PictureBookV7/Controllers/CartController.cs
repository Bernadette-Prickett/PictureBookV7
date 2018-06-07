// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-06-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="CartController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using PictureBookV7.Models.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Controllers
{
    /// <summary>
    /// Class CartController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class CartController : Controller
    {
        // GET: Cart
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
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

        /// <summary>
        /// Carts the partial.
        /// </summary>
        /// <returns>ActionResult.</returns>
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

                model.Quantity = qty;
                model.Price = price;               
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

        /// <summary>
        /// Adds to cart partial.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult AddToCartPartial(int id)
        {
            //Initialise cartVM list
            List<CartVM> cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            //Initialise cartVM
            CartVM model = new CartVM();

            using (Db db = new Db())
            {
                //Get the product
                ProductDTO product = db.Products.Find(id);

                //Check if product is already in cart
                var productInCart = cart.FirstOrDefault(x => x.ProductId == id);

                //If not, add new
                if (productInCart == null)
                {
                    cart.Add(new CartVM()
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Quantity = 1,
                        Price = product.Price,
                        Image = product.ImageName
                    });
                }
                else
                {
                    //If yes, increment
                    productInCart.Quantity++;
                }                
            }

            //Get total qty and price and add to model
            int qty = 0;
            decimal price = 0m;

            foreach (var item in cart)
            {
                qty += item.Quantity;
                price += item.Quantity * item.Price;
            }

            model.Quantity = qty;
            model.Price = price;

            //Save cart back to session
            Session["cart"] = cart;

            //Return partial view wityh model
            return PartialView(model);
        }

        // GET: Cart/IncrementProduct
        /// <summary>
        /// Increments the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult IncrementProduct(int productId)
        {
            //Initialise cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (Db db = new Db())
            {
                //Get cartVm from list
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);

                //Increment qty
                model.Quantity++;

                //Store needed data
                var result = new { qty = model.Quantity, price = model.Price };

                //Return json with data
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            
        }

        // GET: Cart/DecrementProduct
        /// <summary>
        /// Decrements the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult DecrementProduct(int productId)
        {
            //Initialise cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (Db db = new Db())
            {
                //Get cartVm from list
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);

                //Decrement qty
                if(model.Quantity > 1)
                {
                    model.Quantity--;
                }
                else
                {
                    model.Quantity = 0;
                    cart.Remove(model);
                }

                //Store needed data
                var result = new { qty = model.Quantity, price = model.Price };

                //Return json with data
                return Json(result, JsonRequestBehavior.AllowGet);

            }            
        }

        // GET: /Cart/RemoveProduct
        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        public void RemoveProduct(int productId)
        {
            // Initialise cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (Db db = new Db())
            {
                // Get model from list
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);

                // Remove model from list
                cart.Remove(model);
            }

        }

        /// <summary>
        /// Paypals the partial.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult PaypalPartial()
        {
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            return PartialView(cart);
        }

        // POST: /Cart/PlaceOrder
        /// <summary>
        /// Places the order.
        /// </summary>
        [HttpPost]
        public void PlaceOrder()
        {
            //Get cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            //Get username
            string username = User.Identity.Name;

            int orderId = 0;

            using (Db db = new Db())
            {
                //Init OrderDTO
                OrderDTO orderDTO = new OrderDTO();

                //Get user id
                var q = db.Users.FirstOrDefault(x => x.Username == username);
                int userId = q.Id;

                //Add to OrderDTO and save
                orderDTO.UserId = userId;
                orderDTO.DateCreated = DateTime.Now;

                db.Orders.Add(orderDTO);

                db.SaveChanges();

                //Get inserted id
                orderId = orderDTO.OrderId;

                //Init OrderDetailsDTO
                OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO();

                //Add to OrderDetailsDTO
                foreach (var item in cart)
                {
                    orderDetailsDTO.OrderId = orderId;
                    orderDetailsDTO.UserId = userId;
                    orderDetailsDTO.ProductId = item.ProductId;
                    orderDetailsDTO.Quantity = item.Quantity;

                    db.OrderDetails.Add(orderDetailsDTO);

                    db.SaveChanges();
                }
            }

            //Email admin
            var client = new SmtpClient("mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("04b3dd07c4bc9b", "d7e4eb025da2d0"),
                EnableSsl = true
            };
            client.Send("admin@example.com", "admin@example.com", "New Order", "You have a new order. The order number is " + orderId);

            //Reset session
            Session["cart"] = null;
        }
    }
}