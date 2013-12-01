using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCarStore.Models;

namespace MvcCarStore.Controllers
{
    public class StoreController : Controller
    {

        CarStoreEntities storeDB = new CarStoreEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var brandList = storeDB.Brands.ToList();
            return View(brandList);
        }

        public ActionResult Browse(string brand)
        {
            var brandBrowsed = storeDB.Brands.Include("Cars").Single(b => b.CarBrand == brand);
            return View(brandBrowsed);
        }

        public ActionResult Details(int id)
        {
            var car = storeDB.Cars.Find(id);
            return View(car);
        }

    }
}
