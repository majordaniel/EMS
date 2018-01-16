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
    public class DocumentTypeController : Controller
    {
        private EMSDbContext db = new EMSDbContext();

        
        public ActionResult ViewDocumentType()
        {
            return View(db.DocumentTypes.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }


        public ActionResult SaveDocumentType()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDocumentType(DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.DocumentTypes.Add(documentType);
                db.SaveChanges();
                documentType.TypeName=String.Empty;
                documentType.Description=String.Empty;
                ViewBag.Message = "Documents type Successfully Saved";
            }
            ModelState.Clear();
            return View(documentType);
        }


        public ActionResult EditDocumentType(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDocumentType(DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentType).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Documents type Successfully Edited";
            }
            return View(documentType);
        }

      
        public ActionResult DeleteDocumentType(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }


        [HttpPost, ActionName("DeleteDocumentType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentType documentType = db.DocumentTypes.Find(id);
            db.DocumentTypes.Remove(documentType);
            db.SaveChanges();
            ViewBag.Message = "Documents type Successfully Deleted";
            return RedirectToAction("ViewDocumentType");
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
        public JsonResult IsDocumentTypeNameExists(string typename)
        {
            return Json(!db.DocumentTypes.Any(d=>d.TypeName==typename),JsonRequestBehavior.AllowGet);
        }
    }
}
