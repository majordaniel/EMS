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
    public class EmployeeSkillController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /EmployeeSkill/
        public ActionResult ViewEmployeeSkill()
        {
            var employeeskills = db.EmployeeSkills.Include(e => e.Employee).Include(e => e.Skill);
            return View(employeeskills.ToList());
        }

        // GET: /EmployeeSkill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill employeeskill = db.EmployeeSkills.Find(id);
            if (employeeskill == null)
            {
                return HttpNotFound();
            }
            return View(employeeskill);
        }

        // GET: /EmployeeSkill/Create
        public ActionResult SaveEmployeeSkill()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName");
            return View();
        }

        // POST: /EmployeeSkill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployeeSkill([Bind(Include = "Id,EmployeeId,SkillId,Details")] EmployeeSkill employeeskill)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeSkills.Add(employeeskill);
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeSkill");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeeskill.EmployeeId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName", employeeskill.SkillId);
            return View(employeeskill);
        }

        // GET: /EmployeeSkill/Edit/5
        public ActionResult EditEmployeeSkill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill employeeskill = db.EmployeeSkills.Find(id);
            if (employeeskill == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeeskill.EmployeeId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName", employeeskill.SkillId);
            return View(employeeskill);
        }

        // POST: /EmployeeSkill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeSkill([Bind(Include = "Id,EmployeeId,SkillId,Details")] EmployeeSkill employeeskill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeskill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeSkill");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeeskill.EmployeeId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName", employeeskill.SkillId);
            return View(employeeskill);
        }

        // GET: /EmployeeSkill/Delete/5
        public ActionResult DeleteEmployeeSkill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill employeeskill = db.EmployeeSkills.Find(id);
            if (employeeskill == null)
            {
                return HttpNotFound();
            }
            return View(employeeskill);
        }

        // POST: /EmployeeSkill/Delete/5
        [HttpPost, ActionName("DeleteEmployeeSkill")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeSkill employeeskill = db.EmployeeSkills.Find(id);
            db.EmployeeSkills.Remove(employeeskill);
            db.SaveChanges();
            return RedirectToAction("ViewEmployeeSkill");
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
