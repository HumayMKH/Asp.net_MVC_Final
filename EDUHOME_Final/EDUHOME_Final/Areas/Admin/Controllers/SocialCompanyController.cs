using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUHOME_Final.Areas.Admin.Controllers
{
    public class SocialCompanyController : Controller
    {
        // GET: Admin/SocialCompany
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<SocialCompany> socialCompanies = db.SocialCompanies.ToList();
                return View(socialCompanies);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialCompany/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                SocialCompany socialCompany = db.SocialCompanies.Find(Id);
                return View(socialCompany);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialCompany/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Home= db.HomeSettings.ToList();
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(SocialCompany socialCompany)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.SocialCompanies.Add(socialCompany);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                ViewBag.Home = db.HomeSettings.ToList();
                return View(socialCompany);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialCompany/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                SocialCompany socialCompany = db.SocialCompanies.Find(id);
                   
                if (socialCompany == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Home = db.HomeSettings.ToList();
                return View(socialCompany);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(SocialCompany socialCompany)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(socialCompany).State = EntityState.Modified;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Home = db.HomeSettings.ToList();
                return View(socialCompany);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialCompany/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                SocialCompany socialCompany = db.SocialCompanies.Find(id);
                if (socialCompany == null)
                {
                    return HttpNotFound();
                }               
                db.SocialCompanies.Remove(socialCompany);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}