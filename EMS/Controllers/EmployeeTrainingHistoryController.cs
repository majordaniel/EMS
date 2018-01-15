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
    public class EmployeeTrainingHistoryController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /EmployeeTrainingHistory/
        public ActionResult ViewTrainingHistory()
        {
            var employeetraininghistories = db.EmployeeTrainingHistories.Include(e => e.Employee);
            return View(employeetraininghistories.ToList());
        }

        // GET: /EmployeeTrainingHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTrainingHistory employeetraininghistory = db.EmployeeTrainingHistories.Find(id);
            if (employeetraininghistory == null)
            {
                return HttpNotFound();
            }
            return View(employeetraininghistory);
        }

        // GET: /EmployeeTrainingHistory/Create
        public ActionResult SaveTrainingHistory()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            return View();
        }

        // POST: /EmployeeTrainingHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTrainingHistory([Bind(Include = "Id,EmployeeId,TrainingTitle,TrainingTopic,TrainingInstitute,IstituteLocation,InstituteCountry,TrainingYear,TrainingDuration")] EmployeeTrainingHistory employeetraininghistory)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTrainingHistories.Add(employeetraininghistory);
                db.SaveChanges();
                return RedirectToAction("ViewTrainingHistory");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeetraininghistory.EmployeeId);
            return View(employeetraininghistory);
        }

        // GET: /EmployeeTrainingHistory/Edit/5
        public ActionResult EditTrainingHistory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTrainingHistory employeetraininghistory = db.EmployeeTrainingHistories.Find(id);
            if (employeetraininghistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeetraininghistory.EmployeeId);
            return View(employeetraininghistory);
        }

        // POST: /EmployeeTrainingHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrainingHistory([Bind(Include = "Id,EmployeeId,TrainingTitle,TrainingTopic,TrainingInstitute,IstituteLocation,InstituteCountry,TrainingYear,TrainingDuration")] EmployeeTrainingHistory employeetraininghistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeetraininghistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewTrainingHistory");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeetraininghistory.EmployeeId);
            return View(employeetraininghistory);
        }

        // GET: /EmployeeTrainingHistory/Delete/5
        public ActionResult DeleteTrainingHistory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTrainingHistory employeetraininghistory = db.EmployeeTrainingHistories.Find(id);
            if (employeetraininghistory == null)
            {
                return HttpNotFound();
            }
            return View(employeetraininghistory);
        }

        // POST: /EmployeeTrainingHistory/Delete/5
        [HttpPost, ActionName("DeleteTrainingHistory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTrainingHistory employeetraininghistory = db.EmployeeTrainingHistories.Find(id);
            db.EmployeeTrainingHistories.Remove(employeetraininghistory);
            db.SaveChanges();
            return RedirectToAction("ViewTrainingHistory");
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
