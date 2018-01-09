using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS.Gateway;

namespace EMS.Controllers
{
    public class HomeController : Controller
    {
        private EMSDbContext db=new EMSDbContext();
        public ActionResult Index()
        {
            ViewBag.TotalEmployee = db.Employees.Count();
            ViewBag.TotalDepartment = db.Departments.Count();
            ViewBag.TotalDesignation = db.Designations.Count();
            ViewBag.TotalCountry = db.Countries.Count();
            ViewBag.TotalDivision = db.Divisions.Count();
            ViewBag.TotalDistrict = db.Districts.Count();
            ViewBag.TotalPolicestation = db.PoliceStations.Count();
            ViewBag.TotalUnion = db.Unions.Count();
            ViewBag.TotalSkill = db.Skills.Count();
            ViewBag.TotalLanguage = db.Languages.Count();
            ViewBag.CertificationCount = db.Certifications.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}