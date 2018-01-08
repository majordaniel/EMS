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
    public class LanguageController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Language/
        public ActionResult ViewLanguage()
        {
            return View(db.Languages.ToList());
        }

        // GET: /Language/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // GET: /Language/Create
        public ActionResult SaveLanguage()
        {
            return View();
        }

        // POST: /Language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveLanguage(Language language)
        {
            if (ModelState.IsValid)
            {
                db.Languages.Add(language);
                db.SaveChanges();
                return RedirectToAction("ViewLanguage");
            }

            return View(language);
        }

        // GET: /Language/Edit/5
        public ActionResult EditLanguage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: /Language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLanguage(Language language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewLanguage");
            }
            return View(language);
        }

        // GET: /Language/Delete/5
        public ActionResult DeleteLanguage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: /Language/Delete/5
        [HttpPost, ActionName("DeleteLanguage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
            db.SaveChanges();
            return RedirectToAction("ViewLanguage");
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
        public JsonResult IsLanguageCodeExists(string languagecode)
        {
            return Json(!db.Languages.Any(l => l.LanguageCode == languagecode), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsLanguageNameExists(string languagename)
        {
            return Json(!db.Languages.Any(l => l.LanguageName == languagename), JsonRequestBehavior.AllowGet);
        }
    }
}
