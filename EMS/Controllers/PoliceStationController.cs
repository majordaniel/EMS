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
    public class PoliceStationController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /PoliceStation/
        public ActionResult ViewAllPoliceSation()
        {
            var policestations = db.PoliceStations.Include(p => p.District);
            return View(policestations.ToList());
        }

        // GET: /PoliceStation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceStation policestation = db.PoliceStations.Find(id);
            if (policestation == null)
            {
                return HttpNotFound();
            }
            return View(policestation);
        }

        // GET: /PoliceStation/Create
        public ActionResult SavePoliceStation()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName");
            return View();
        }

        // POST: /PoliceStation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePoliceStation([Bind(Include = "Id,DistrictId,PoliceStationCode,PoliceStationName")] PoliceStation policestation)
        {
            if (ModelState.IsValid)
            {
                db.PoliceStations.Add(policestation);
                db.SaveChanges();
                return RedirectToAction("ViewAllPoliceSation");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName", policestation.DistrictId);
            return View(policestation);
        }

        // GET: /PoliceStation/Edit/5
        public ActionResult EditPoliceStation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceStation policestation = db.PoliceStations.Find(id);
            if (policestation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName", policestation.DistrictId);
            return View(policestation);
        }

        // POST: /PoliceStation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPoliceStation([Bind(Include = "Id,DistrictId,PoliceStationCode,PoliceStationName")] PoliceStation policestation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policestation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAllPoliceSation");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName", policestation.DistrictId);
            return View(policestation);
        }

        // GET: /PoliceStation/Delete/5
        public ActionResult DeletePoliceStation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceStation policestation = db.PoliceStations.Find(id);
            if (policestation == null)
            {
                return HttpNotFound();
            }
            return View(policestation);
        }

        // POST: /PoliceStation/Delete/5
        [HttpPost, ActionName("DeletePoliceStation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoliceStation policestation = db.PoliceStations.Find(id);
            db.PoliceStations.Remove(policestation);
            db.SaveChanges();
            return RedirectToAction("ViewAllPoliceSation");
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
        public JsonResult IsPoliceStationCodeExists(string policestationCode)
        {
            return Json(!db.PoliceStations.Any(c => c.PoliceStationCode == policestationCode), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsPoliceStationNameExists(string policestationName)
        {
            return Json(!db.PoliceStations.Any(c => c.PoliceStationName == policestationName), JsonRequestBehavior.AllowGet);
        }
    }
}
