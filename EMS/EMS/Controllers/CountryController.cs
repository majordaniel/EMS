using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Gateway;
using EMS.Models;

namespace EMS.Controllers
{
    public class CountryController : Controller
    {
        private EMSDbContext db = new EMSDbContext();
        //
        // GET: /Country/
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        public ActionResult SaveCountry()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("SaveCountry");
            }
            return View(country);
        }

        public ActionResult EditCountry(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country==null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SaveCountry");
            }
            return View(country);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("SaveCountry");
        }

        [HttpPost]
        public JsonResult IsCountryCodeExists(string countrycode)
        {
            return Json(!db.Countries.Any(c => c.CountryCode == countrycode), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsCountryNameExists(string countryname)
        {
            return Json(!db.Countries.Any(c => c.CountryName == countryname), JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult _ShowCountry()
        {
            List<Country> countries = db.Countries.OrderBy(c => c.CountryName).ToList<Country>();
            return PartialView(countries.ToList()); 
        }
    }
}