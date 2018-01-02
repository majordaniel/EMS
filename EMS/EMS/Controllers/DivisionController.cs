using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;
using EMS.Gateway;

namespace EMS.Controllers
{
    public class DivisionController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Division/
        public ActionResult Index()
        {
            var divisions = db.Divisions.Include(d => d.Country);
            return View(divisions.ToList());
        }

        // GET: /Division/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

       
        public ActionResult SaveDivision()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDivision([Bind(Include = "Id,CountryId,DivisionCode,DivisionName")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Add(division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", division.CountryId);
            return View(division);
        }

        // GET: /Division/Edit/5
        public ActionResult EditDivsion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryCode", division.CountryId);
            return View(division);
        }

        // POST: /Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDivsion([Bind(Include = "Id,CountryId,DivisionCode,DivisionName")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryCode", division.CountryId);
            return View(division);
        }

        // GET: /Division/Delete/5
        public ActionResult DeleteDivision(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Division/Delete/5
        [HttpPost, ActionName("DeleteDivision")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Division division = db.Divisions.Find(id);
            db.Divisions.Remove(division);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult IsDivisionCodeExists(string divisionCode)
        {
            return Json(!db.Divisions.Any(c => c.DivisionCode == divisionCode), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsDivisionNameExists(string divisionName)
        {
            return Json(!db.Divisions.Any(c => c.DivisionName == divisionName), JsonRequestBehavior.AllowGet);
        }
    }
}
