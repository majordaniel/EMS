using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;
using EMS.Gateway;

namespace EMS.Controllers
{
    public class EmployeeDocumentController : Controller
    {
        private EMSDbContext db = new EMSDbContext();


        public ActionResult ViewEmployeeDocuments()
        {
            var employeedocuments = db.EmployeeDocuments.Include(e => e.DocumentType).Include(e => e.Employee);
            return View(employeedocuments.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDocument employeedocument = db.EmployeeDocuments.Find(id);
            if (employeedocument == null)
            {
                return HttpNotFound();
            }
            return View(employeedocument);
        }


        public ActionResult SaveEmployeeDocuments()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "TypeName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployeeDocuments(EmployeeDocument employeedocument, HttpPostedFileBase file)
        {
            
            //if (ModelState.IsValid)
            //{
            //    if (file != null)
            //    {
            //        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //        string extension = Path.GetExtension(file.FileName);
            //        fileName = fileName + DateTime.Now.ToString("yymmdd") + extension;
            //        employeedocument.FilePath = "~/Documents/" + fileName;
            //        fileName = Path.Combine(Server.MapPath("~/Documents/"), fileName);
            //        file.SaveAs(Path.Combine(fileName));
            //        employeedocument.FilePath = fileName;
            //    }
            //    using (EMSDbContext dc = new EMSDbContext())
            //    {
            //        dc.EmployeeDocuments.Add(employeedocument);
            //        dc.SaveChanges();
            //    }
            //    ModelState.Clear();
            //    ViewBag.FileStatus = "File uploaded successfully.";
            //}

            if (ModelState.IsValid)
            {
                db.EmployeeDocuments.Add(employeedocument);
                db.SaveChanges();
                ViewBag.FileStatus = "File uploaded successfully.";
            }
            ModelState.Clear();
            
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "TypeName", employeedocument.DocumentTypeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeedocument.EmployeeId);

            return View(employeedocument);

        }

       
        public ActionResult EditEmployeeDocuments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDocument employeedocument = db.EmployeeDocuments.Find(id);
            if (employeedocument == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "TypeName", employeedocument.DocumentTypeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeedocument.EmployeeId);
            return View(employeedocument);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeDocuments([Bind(Include = "Id,EmployeeId,DocumentTypeId,DocumentTitle,DocumentAddedDate,ExpiredDate,Details,FilePath")] EmployeeDocument employeedocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeedocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeDocuments");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "TypeName", employeedocument.DocumentTypeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeRegNo", employeedocument.EmployeeId);
            return View(employeedocument);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDocument employeedocument = db.EmployeeDocuments.Find(id);
            if (employeedocument == null)
            {
                return HttpNotFound();
            }
            return View(employeedocument);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDocument employeedocument = db.EmployeeDocuments.Find(id);
            db.EmployeeDocuments.Remove(employeedocument);
            db.SaveChanges();
            return RedirectToAction("ViewEmployeeDocuments");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult GetUplodedDocumentData()
        {
            var res = "";
            if (Session["DocumentUpload"] != null)
            {
                res = Session["DocumentUpload"].ToString();
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }

    
}
