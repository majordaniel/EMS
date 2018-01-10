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
    public class EmploymentHistoryController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /EmploymentHistory/
        public ActionResult ViewEmploymentHistory()
        {
            var employmenthistories = db.EmploymentHistories.Include(e => e.Department).Include(e => e.Designation).Include(e => e.Employee);
            return View(employmenthistories.ToList());
        }

        // GET: /EmploymentHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            if (employmenthistory == null)
            {
                return HttpNotFound();
            }
            return View(employmenthistory);
        }

        // GET: /EmploymentHistory/Create
        public ActionResult SaveEmploymentHistory()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            return View();
        }

        // POST: /EmploymentHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmploymentHistory([Bind(Include = "Id,EmployeeId,CompanyName,CompanyLocation,DepartmentId,DesignationId,EmploymentFromDate,IsCurrentEmployee,EmploymentToDate,Responsibilities")] EmploymentHistory employmenthistory)
        {
            if (ModelState.IsValid)
            {
                db.EmploymentHistories.Add(employmenthistory);
                db.SaveChanges();
                return RedirectToAction("ViewEmploymentHistory");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode", employmenthistory.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode", employmenthistory.DesignationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employmenthistory.EmployeeId);
            return View(employmenthistory);
        }

        // GET: /EmploymentHistory/Edit/5
        public ActionResult EditEmploymentHistory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            if (employmenthistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode", employmenthistory.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode", employmenthistory.DesignationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employmenthistory.EmployeeId);
            return View(employmenthistory);
        }

        // POST: /EmploymentHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmploymentHistory([Bind(Include = "Id,EmployeeId,CompanyName,CompanyLocation,DepartmentId,DesignationId,EmploymentFromDate,IsCurrentEmployee,EmploymentToDate,Responsibilities")] EmploymentHistory employmenthistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employmenthistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmploymentHistory");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode", employmenthistory.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode", employmenthistory.DesignationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employmenthistory.EmployeeId);
            return View(employmenthistory);
        }

        // GET: /EmploymentHistory/Delete/5
        public ActionResult DeleteEmploymentHistory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            if (employmenthistory == null)
            {
                return HttpNotFound();
            }
            return View(employmenthistory);
        }

        // POST: /EmploymentHistory/Delete/5
        [HttpPost, ActionName("DeleteEmploymentHistory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            db.EmploymentHistories.Remove(employmenthistory);
            db.SaveChanges();
            return RedirectToAction("ViewEmploymentHistory");
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
