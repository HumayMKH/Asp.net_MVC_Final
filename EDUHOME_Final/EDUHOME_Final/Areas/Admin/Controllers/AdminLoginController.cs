using EDUHOME_Final.DAL;
using EDUHOME_Final.Migrations;
using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUHOME_Final.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<AdmiNLogin> admins = db.AdmiNLogins.ToList();
                return View(admins);
            }
            return RedirectToAction("Login", "Login");
        }
    }
}