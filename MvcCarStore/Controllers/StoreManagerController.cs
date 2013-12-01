using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCarStore.Models;

namespace MvcCarStore.Controllers
{ 
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private CarStoreEntities db = new CarStoreEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var cars = db.Cars.Include(a => a.BrandName);
            return View(cars.ToList());
            
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "CarBrand");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "CarBrand", car.BrandID);
            
            return View(car);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Car car = db.Cars.Find(id);

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "CarBrand", car.BrandID);
            return View(car);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "CarBrand", car.BrandID);
            return View(car);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}