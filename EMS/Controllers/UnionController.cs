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
    public class UnionController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Union/
        public ActionResult ViewAllUnion()
        {
            var unions = db.Unions.Include(u => u.PoliceStation);
            return View(unions.ToList());
        }

        // GET: /Union/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Union union = db.Unions.Find(id);
            if (union == null)
            {
                return HttpNotFound();
            }
            return View(union);
        }

        // GET: /Union/Create
        public ActionResult SaveUnion()
        {
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName");
            return View();
        }

        // POST: /Union/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUnion([Bind(Include = "Id,PoliceStationId,UnionCode,UnionName")] Union union)
        {
            if (ModelState.IsValid)
            {
                db.Unions.Add(union);
                db.SaveChanges();
                return RedirectToAction("ViewAllUnion");
            }

            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", union.PoliceStationId);
            return View(union);
        }

        // GET: /Union/Edit/5
        public ActionResult EditUnion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Union union = db.Unions.Find(id);
            if (union == null)
            {
                return HttpNotFound();
            }
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", union.PoliceStationId);
            return View(union);
        }

        // POST: /Union/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUnion([Bind(Include = "Id,PoliceStationId,UnionCode,UnionName")] Union union)
        {
            if (ModelState.IsValid)
            {
                db.Entry(union).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAllUnion");
            }
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationName", union.PoliceStationId);
            return View(union);
        }

        // GET: /Union/Delete/5
        public ActionResult DeleteUnion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Union union = db.Unions.Find(id);
            if (union == null)
            {
                return HttpNotFound();
            }
            return View(union);
        }

        // POST: /Union/Delete/5
        [HttpPost, ActionName("DeleteUnion")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Union union = db.Unions.Find(id);
            db.Unions.Remove(union);
            db.SaveChanges();
            return RedirectToAction("ViewAllUnion");
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
        public JsonResult IsUnionCodeExists(string unioncode)
        {
            return Json(!db.Unions.Any(u => u.UnionCode == unioncode), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsUnionNameExists(string unionname)
        {
            return Json(!db.Unions.Any(u => u.UnionName == unionname), JsonRequestBehavior.AllowGet);
        }
    }
}
