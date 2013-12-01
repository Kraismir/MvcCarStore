using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCarStore.Models;
using MvcCarStore.ViewModels;

namespace MvcCarStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        CarStoreEntities storeDB = new CarStoreEntities();
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems =  cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        //GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            var addedCar = storeDB.Cars.Single(car => car.CarID == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedCar);

            return RedirectToAction("Index");
        }

        //AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            string carModel = storeDB.Carts.Single(item => item.RecordID == id).Car.Model;

            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel()
            {
                Message = Server.HtmlEncode(carModel) + " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteID = id
            };

            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}
