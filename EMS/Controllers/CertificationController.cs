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
    public class CertificationController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Certification/
        public ActionResult ViewCertificate()
        {
            ViewBag.CertificationCount = db.Certifications.Count();
            return View(db.Certifications.ToList());
        }

        // GET: /Certification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // GET: /Certification/Create
        public ActionResult SaveCertification()
        {
            return View();
        }

        // POST: /Certification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCertification(Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Certifications.Add(certification);
                db.SaveChanges();
                ViewBag.Message = "Successfully saved";
            }

            return View(certification);
        }

        // GET: /Certification/Edit/5
        public ActionResult EditCertification(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: /Certification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCertification(Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewCertificate");
            }
            return View(certification);
        }

        // GET: /Certification/Delete/5
        public ActionResult DeleteCertification(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: /Certification/Delete/5
        [HttpPost, ActionName("DeleteCertification")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certification certification = db.Certifications.Find(id);
            db.Certifications.Remove(certification);
            db.SaveChanges();
            return RedirectToAction("ViewCertificate");
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
        public JsonResult IsCertificationNameExists(string certificationname)
        {
            return Json(!db.Certifications.Any(c => c.CertificationName == certificationname),
                JsonRequestBehavior.AllowGet);
        }
    }
}
