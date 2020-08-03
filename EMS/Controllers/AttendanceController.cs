using EMS.Gateway;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class AttendanceController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        public ActionResult ViewAttendance()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaveAttendance()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAttendance(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("ViewAttendance");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", attendance.EmployeeId);
            return View();
        }


    }
}