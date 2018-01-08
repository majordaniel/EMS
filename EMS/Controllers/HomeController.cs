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