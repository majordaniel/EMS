using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EMS.Gateway;
using EMS.Models;
using EMS.Models.User;

namespace EMS.Controllers.User
{
    public class AppUserController : Controller
    {
        private EMSDbContext db=new EMSDbContext();
        //
       
        public ActionResult ViewUser()
        {
            var appUser = db.AppUsers.Include(e => e.Role);
            return View(appUser.ToList());
        }

       
        [HttpGet]
        public ActionResult Registration()
        {
           
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(AppUser user)
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", user.RoleId);
            bool Status = false;
            string errMessage = "";
            string successMessage = "";
            
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExist = IsEmailExists(user.EmailAddress);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region //User name is already Exist
                var isUserNameExists = IsUserNameExists(user.UserName);
                if (isUserNameExists)
                {
                    ModelState.AddModelError("UserExists", "User name already exist");
                    return View(user);
                }
                #endregion

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion

                #region Save to Database
                    db.AppUsers.Add(user);
                    db.SaveChanges();
                    successMessage = "Registration successfully done"; 
                Status = true;
                #endregion
            }
            else
            {
                errMessage = "Invalid Request";
            }
            ModelState.Clear();
            ViewBag.ErrorMessage = errMessage;
            ViewBag.SuccessMessage = successMessage;
            ViewBag.Status = Status;
            return View(user);
        }
        
        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AppUserLogin login, string ReturnUrl="")
        {
            string message = "";
            using (EMSDbContext dc = new EMSDbContext())
            {
                var validUser = dc.AppUsers.Where(a => a.UserName == login.UserName).FirstOrDefault();
                if (validUser != null)
                {
                    

                    if (string.Compare(Crypto.Hash(login.Password),validUser.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.UserName, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AppUser");
        }


        [NonAction]
        public bool IsEmailExists(string emailID)
        {
            using (EMSDbContext dc = new EMSDbContext())
            {
                var v = dc.AppUsers.Where(a => a.EmailAddress == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public bool IsUserNameExists(string username)
        {
            using (EMSDbContext dc = new EMSDbContext())
            {
                var v = dc.AppUsers.Where(a => a.UserName == username).FirstOrDefault();
                return v != null;
            }   
        }
    }
}