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
    public class EmployeeCertificationController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /EmployeeCertification/
        public ActionResult ViewEmployeeCertification()
        {
            var employeecertifications = db.EmployeeCertifications.Include(e => e.Employee).Include(e => e.Certification);
            return View(employeecertifications.ToList());
        }

        // GET: /EmployeeCertification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCertification employeecertification = db.EmployeeCertifications.Find(id);
            if (employeecertification == null)
            {
                return HttpNotFound();
            }
            return View(employeecertification);
        }

        // GET: /EmployeeCertification/Create
        public ActionResult SaveEmployeeCertification()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "CertificationName");
            return View();
        }

        // POST: /EmployeeCertification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployeeCertification([Bind(Include = "Id,EmployeeId,CertificationId,InstituteName,FromDate,ToDate")] EmployeeCertification employeecertification)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeCertifications.Add(employeecertification);
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeCertification");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo",employeecertification.EmployeeId);
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "CertificationName", employeecertification.CertificationId);
            return View(employeecertification);
        }

        // GET: /EmployeeCertification/Edit/5
        public ActionResult EditEmployeeCertification(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCertification employeecertification = db.EmployeeCertifications.Find(id);
            if (employeecertification == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeecertification.EmployeeId);
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "CertificationName", employeecertification.CertificationId);
            return View(employeecertification);
        }

        // POST: /EmployeeCertification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeCertification([Bind(Include = "Id,EmployeeId,CertificationId,InstituteName,FromDate,ToDate")] EmployeeCertification employeecertification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeecertification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeCertification");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeecertification.EmployeeId);
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "CertificationName", employeecertification.CertificationId);
            return View(employeecertification);
        }

        // GET: /EmployeeCertification/Delete/5
        public ActionResult DeleteEmployeeCertification(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCertification employeecertification = db.EmployeeCertifications.Find(id);
            if (employeecertification == null)
            {
                return HttpNotFound();
            }
            return View(employeecertification);
        }

        // POST: /EmployeeCertification/Delete/5
        [HttpPost, ActionName("DeleteEmployeeCertification")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeCertification employeecertification = db.EmployeeCertifications.Find(id);
            db.EmployeeCertifications.Remove(employeecertification);
            db.SaveChanges();
            return RedirectToAction("ViewEmployeeCertification");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult GetEmployeeInfoById(int employeeId)
        {
            var employee = db.Employees.Where(c => c.Id == employeeId).Select(c => new { name = c.EmployeeName, email = c.Email, nid = c.NationalID, department = c.Department }).FirstOrDefault();
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}
