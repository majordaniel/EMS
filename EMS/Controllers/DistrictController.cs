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
    public class DistrictController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /District/
        public ActionResult Index()
        {
            var districts = db.Districts.Include(d => d.Division);
            return View(districts.ToList());
        }

        // GET: /District/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: /District/Create
        public ActionResult SaveDistrict()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionName");
            return View();
        }

        // POST: /District/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDistrict([Bind(Include = "Id,DivisionId,DistrictCode,DistrictName")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionName", district.DivisionId);
            return View(district);
        }

        // GET: /District/Edit/5
        public ActionResult EditDistrict(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionName", district.DivisionId);
            return View(district);
        }

        // POST: /District/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDistrict([Bind(Include = "Id,DivisionId,DistrictCode,DistrictName")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionName", district.DivisionId);
            return View(district);
        }

        // GET: /District/Delete/5
        public ActionResult DeleteDistrict(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: /District/Delete/5
        [HttpPost, ActionName("DeleteDistrict")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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
        public JsonResult IsDistrictCodeExists(string districtCode)
        {
            return Json(!db.Districts.Any(c => c.DistrictCode == districtCode), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsDistrictNameExists(string districtName)
        {
            return Json(!db.Districts.Any(c => c.DistrictName == districtName), JsonRequestBehavior.AllowGet);
        }


    }
}
