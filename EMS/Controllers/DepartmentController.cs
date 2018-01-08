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
    public class DepartmentController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Department/
        public ActionResult ViewAllDepartment()
        {
            return View(db.Departments.ToList());
        }

        // GET: /Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("ViewAllDepartment");
            }

            return View(department);
        }

        [HttpGet]
        public ActionResult EditDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAllDepartment");
            }
            return View(department);
        }

        [HttpGet]
        public ActionResult DeleteDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        [HttpPost, ActionName("DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("ViewAllDepartment");
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
        public JsonResult IsDepartmentCodeEixsts(string departmentcode)
        {
            return Json(!db.Departments.Any(d => d.DepartmentCode == departmentcode), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsDepartmentNameExists(string departmentname)
        {
            return Json(!db.Departments.Any(d => d.DepartmentName == departmentname), JsonRequestBehavior.AllowGet);
        }
    }
}
