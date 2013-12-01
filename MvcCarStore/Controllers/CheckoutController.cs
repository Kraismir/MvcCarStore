using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCarStore.Models;

namespace MvcCarStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        CarStoreEntities storeDB = new CarStoreEntities();
        private const string PromoCode = "Free";

        //
        // POST: /Checkout/AddressAndPayment/

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new {id = order.OrderID});

                }
            }
            catch
            {
                return View(order);
            }

        }

        // GET : /Checkout/Complete
        public ActionResult Complete(int id)
        {
            bool isValid = storeDB.Orders.Any(o => o.OrderID == id && o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
