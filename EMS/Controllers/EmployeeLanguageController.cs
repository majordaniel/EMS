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
    public class EmployeeLanguageController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /EmployeeLanguage/
        public ActionResult ViewEmployeeLanguage()
        {
            var employeelanguages = db.EmployeeLanguages.Include(e => e.Employee).Include(e => e.Language);
            return View(employeelanguages.ToList());
        }

        // GET: /EmployeeLanguage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLanguage employeelanguage = db.EmployeeLanguages.Find(id);
            if (employeelanguage == null)
            {
                return HttpNotFound();
            }
            return View(employeelanguage);
        }

        // GET: /EmployeeLanguage/Create
        public ActionResult SaveEmployeeLanguage()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "LanguageName");
            return View();
        }

        // POST: /EmployeeLanguage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployeeLanguage([Bind(Include = "Id,EmployeeId,LanguageId,Reading,Speaking,Writing,Understanding")] EmployeeLanguage employeelanguage)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeLanguages.Add(employeelanguage);
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeLanguage");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeelanguage.EmployeeId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "LanguageName", employeelanguage.LanguageId);
            return View(employeelanguage);
        }

        // GET: /EmployeeLanguage/Edit/5
        public ActionResult EditEmployeeLanguage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLanguage employeelanguage = db.EmployeeLanguages.Find(id);
            if (employeelanguage == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeelanguage.EmployeeId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "LanguageName", employeelanguage.LanguageId);
            return View(employeelanguage);
        }

        // POST: /EmployeeLanguage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeLanguage([Bind(Include = "Id,EmployeeId,LanguageId,Reading,Speaking,Writing,Understanding")] EmployeeLanguage employeelanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeelanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeLanguage");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeelanguage.EmployeeId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "LanguageName", employeelanguage.LanguageId);
            return View(employeelanguage);
        }

        // GET: /EmployeeLanguage/Delete/5
        public ActionResult DeleteEmployeeLanguage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLanguage employeelanguage = db.EmployeeLanguages.Find(id);
            if (employeelanguage == null)
            {
                return HttpNotFound();
            }
            return View(employeelanguage);
        }

        // POST: /EmployeeLanguage/Delete/5
        [HttpPost, ActionName("DeleteEmployeeLanguage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeLanguage employeelanguage = db.EmployeeLanguages.Find(id);
            db.EmployeeLanguages.Remove(employeelanguage);
            db.SaveChanges();
            return RedirectToAction("ViewEmployeeLanguage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
