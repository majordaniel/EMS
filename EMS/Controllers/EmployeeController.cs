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
    public class EmployeeController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        // GET: /Employee/
        public ActionResult ViewEmployee()
        {
            var employees = db.Employees.Include(e => e.Country).Include(e => e.Department).Include(e => e.Designation).Include(e => e.District).Include(e => e.Division).Include(e => e.PoliceStation).Include(e => e.Union);
            return View(employees.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult SaveEmployee()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryCode");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode");
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictCode");
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode");
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationCode");
            ViewBag.UnionId = new SelectList(db.Unions, "Id", "UnionCode");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeRegNo = GetEmployeeRegNo(employee);
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ViewEmployee");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryCode", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode", employee.DesignationId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictCode", employee.DistrictId);
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode", employee.DivisionId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationCode", employee.PoliceStationId);
            ViewBag.UnionId = new SelectList(db.Unions, "Id", "UnionCode", employee.UnionId);
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryCode", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode", employee.DesignationId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictCode", employee.DistrictId);
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode", employee.DivisionId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationCode", employee.PoliceStationId);
            ViewBag.UnionId = new SelectList(db.Unions, "Id", "UnionCode", employee.UnionId);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmployee");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryCode", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentCode", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationCode", employee.DesignationId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictCode", employee.DistrictId);
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode", employee.DivisionId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "Id", "PoliceStationCode", employee.PoliceStationId);
            ViewBag.UnionId = new SelectList(db.Unions, "Id", "UnionCode", employee.UnionId);
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("ViewEmployee");
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
        public JsonResult IsEmailExists(string Email)
        {
            return Json(!db.Employees.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsMobileExists(string Mobile)
        {
            return Json(!db.Employees.Any(x => x.Mobile == Mobile), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsNationalIDExists(string NationalId)
        {
            return Json(!db.Employees.Any(x => x.NationalID == NationalId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDivision(int countryId)
        {
            using (EMSDbContext db = new EMSDbContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Division> divisions = db.Divisions.Where(d => d.CountryId == countryId).ToList();
                return Json(divisions, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDistrict(int divisionId)
        {
            using (EMSDbContext db = new EMSDbContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<District> zillas = db.Districts.Where(d => d.DivisionId == divisionId).ToList();
                return Json(zillas, JsonRequestBehavior.AllowGet);
            }
        }

        //For Upozella
        public JsonResult GetPolicestation(int districtId)
        {
            using (EMSDbContext db = new EMSDbContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<PoliceStation> upozellas = db.PoliceStations.Where(d => d.DistrictId == districtId).ToList();
                return Json(upozellas, JsonRequestBehavior.AllowGet);
            }
        }

        //For Union
        public JsonResult GetUnion(int policeStationId)
        {
            using (EMSDbContext db = new EMSDbContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Union> unions = db.Unions.Where(d => d.PoliceStationId == policeStationId).ToList();
                return Json(unions, JsonRequestBehavior.AllowGet);
            }
        }

        public string GetEmployeeRegNo(Employee employee)
        {
            var concatenate =
                db.Employees.Count(m => (m.DepartmentId == employee.DepartmentId) && (m.DesignationId == employee.DesignationId)) +
                1;

            var department = db.Departments.FirstOrDefault(m => m.Id == employee.DepartmentId);
            var designation = db.Designations.FirstOrDefault(m => m.Id == employee.DesignationId);

            string leadingZero = "";
            int length = 3 - concatenate.ToString().Length;
            for (int i = 0; i < length; i++)
            {
                leadingZero += "0";
            }

            string employeeRegNo = department.DepartmentCode + "-" + designation.DesignationCode + "-" + leadingZero + concatenate;
            return employeeRegNo;
        }



    }
}
