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
    public class ExamController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Exam/
        public ActionResult ViewExam()
        {
            var exams = db.Exams.Include(e => e.Education);
            return View(exams.ToList());
        }

        // GET: /Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: /Exam/Create
        public ActionResult SaveExam()
        {
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName");
            return View();
        }

        // POST: /Exam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("ViewExam");
            }

            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName", exam.EducationId);
            return View(exam);
        }

        // GET: /Exam/Edit/5
        public ActionResult EditExam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName", exam.EducationId);
            return View(exam);
        }

        // POST: /Exam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewExam");
            }
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "EducationName", exam.EducationId);
            return View(exam);
        }

        // GET: /Exam/Delete/5
        public ActionResult DeleteExam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: /Exam/Delete/5
        [HttpPost, ActionName("DeleteExam")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("ViewExam");
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
        public ActionResult IsExamNameExists(string examname)
        {
            return Json(!db.Exams.Any(e => e.ExamName == examname), JsonRequestBehavior.AllowGet);
        }
    }
}
