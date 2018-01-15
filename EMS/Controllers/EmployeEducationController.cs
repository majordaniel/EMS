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
    public class EmployeEducationController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /EmployeEducation/
        public ActionResult ViewEmployeeEducation()
        {
            var employeeducations = db.EmployeEducations.Include(e => e.Education).Include(e => e.Employee).Include(e => e.Exam);
            return View(employeeducations.ToList());
        }

        // GET: /EmployeEducation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeEducation employeeducation = db.EmployeEducations.Find(id);
            if (employeeducation == null)
            {
                return HttpNotFound();
            }
            return View(employeeducation);
        }

        // GET: /EmployeEducation/Create
        public ActionResult SaveEmployeeEducation()
        {
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "ExamName");
            return View();
        }

        // POST: /EmployeEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployeeEducation([Bind(Include = "Id,EmployeeId,EducationId,ExamId,Subject,InstituteName,FromDate,ToDate,Duration,PassingYear")] EmployeEducation employeeducation)
        {
            if (ModelState.IsValid)
            {
                db.EmployeEducations.Add(employeeducation);
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeEducation");
            }

            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName", employeeducation.EducationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", employeeducation.EmployeeId);
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "ExamName", employeeducation.ExamId);
            return View(employeeducation);
        }

        // GET: /EmployeEducation/Edit/5
        public ActionResult EditEmployeeEducation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeEducation employeeducation = db.EmployeEducations.Find(id);
            if (employeeducation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName", employeeducation.EducationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeeducation.EmployeeId);
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "ExamName", employeeducation.ExamId);
            return View(employeeducation);
        }

        // POST: /EmployeEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeEducation([Bind(Include = "Id,EmployeeId,EducationId,ExamId,Subject,InstituteName,FromDate,ToDate,Duration,PassingYear")] EmployeEducation employeeducation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeducation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeEducation");
            }
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName", employeeducation.EducationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeeducation.EmployeeId);
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "ExamName", employeeducation.ExamId);
            return View(employeeducation);
        }

        // GET: /EmployeEducation/Delete/5
        public ActionResult DeleteEmployeeEducation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeEducation employeeducation = db.EmployeEducations.Find(id);
            if (employeeducation == null)
            {
                return HttpNotFound();
            }
            return View(employeeducation);
        }

        // POST: /EmployeEducation/Delete/5
        [HttpPost, ActionName("DeleteEmployeeEducation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeEducation employeeducation = db.EmployeEducations.Find(id);
            db.EmployeEducations.Remove(employeeducation);
            db.SaveChanges();
            return RedirectToAction("ViewEmployeeEducation");
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

        public JsonResult GetExam(int educationId)
        {
            using (EMSDbContext db = new EMSDbContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Exam> exams = db.Exams.Where(e => e.EducationId == educationId).ToList();
                return Json(exams, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
