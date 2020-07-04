using EDUHOME_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDUHOME_Final.Models;
using EDUHOME_Final.DAL;
using System.Web.Helpers;

namespace EDUHOME_Final.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        EduHomeContext db = new EduHomeContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VmLogin login)
        {           
            if (ModelState.IsValid)
            {
                AdmiNLogin admin = db.AdmiNLogins.FirstOrDefault(a => a.Username == login.Username);

                if (admin != null)
                {
                    if (admin.Password==login.Password)
                    {
                        Session["Admin"] = admin;
                        Session["AdminId"] = admin.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wronge");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Wronge");
                }
            }
            return View();           
        }

        // GET: Admin/Logout
        public ActionResult Logout()
        {         
                Session["Admin"] = null;
                Session["AdminId"] = null;

                return RedirectToAction("Login", "Login");           
        }
    }
}