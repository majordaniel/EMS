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
    public class DesignationController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Designation/
        public ActionResult ViewDesignation()
        {
            return View(db.Designations.ToList());
        }

        // GET: /Designation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        //GET:
        [HttpGet]
        public ActionResult SaveDesignation()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDesignation(Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                db.SaveChanges();
                return RedirectToAction("ViewDesignation");
            }

            return View(designation);
        }

        // GET: /Designation/Edit/5
        public ActionResult EditDesignation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDesignation(Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewDesignation");
            }
            return View(designation);
        }

        // GET: /Designation/Delete/5
        public ActionResult DeleteDesignation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: /Designation/Delete/5
        [HttpPost, ActionName("DeleteDesignation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = db.Designations.Find(id);
            db.Designations.Remove(designation);
            db.SaveChanges();
            return RedirectToAction("ViewDesignation");
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
        public JsonResult IsDesignationCodeExists(string designationcode)
        {
            return Json(!db.Designations.Any(d => d.DesignationCode == designationcode), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsDesignationNameExists(string designationname)
        {
            return Json(!db.Designations.Any(d => d.DesignationName == designationname), JsonRequestBehavior.AllowGet);
        }
    }
}
