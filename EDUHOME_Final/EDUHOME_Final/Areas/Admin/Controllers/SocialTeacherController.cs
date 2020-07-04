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
    public class SocialTeacherController : Controller
    {
        // GET: Admin/SocialTeacher
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<SocialTeacher> socialTeachers = db.SocialTeachers.ToList();
                return View(socialTeachers);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialTeacher/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                SocialTeacher socialTeachers = db.SocialTeachers.Find(Id);
                return View(socialTeachers);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialTeacher/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Teacher = db.Teachers.ToList();
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(SocialTeacher socialTeachers)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.SocialTeachers.Add(socialTeachers);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                ViewBag.Teacher = db.Teachers.ToList();
                return View(socialTeachers);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialTeacher/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                SocialTeacher socialTeachers = db.SocialTeachers.Find(id);
                if (socialTeachers == null)
                {
                    return HttpNotFound();
                }                
                ViewBag.Teacher = db.Teachers.ToList();
                return View(socialTeachers);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(SocialTeacher socialTeachers)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                    {
                    db.Entry(socialTeachers).State = EntityState.Modified;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Teacher = db.Teachers.ToList();
                return View(socialTeachers);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SocialTeacher/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                 SocialTeacher socialTeachers = db.SocialTeachers.Find(id);
                 if (socialTeachers == null)
                 {
                     return HttpNotFound();
                 }                 
                 db.SocialTeachers.Remove(socialTeachers);
                 db.SaveChanges();
                 
                 return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}