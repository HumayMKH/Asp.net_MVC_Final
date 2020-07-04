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
    public class NoticeController : Controller
    {
        // GET: Admin/Notice
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<Notice> notice = db.Notices.ToList();
                return View(notice);
            }
            return RedirectToAction("Login", "Login");
        }

        // Admin/Notice/Details
        public ActionResult Details(int id)
        {
            if (Session["Admin"] != null)
            {
                Notice notice = db.Notices.Find(id);
                return View(notice);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Notice/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(Notice notice)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Notices.Add(notice);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Login", "Login");
            }
            return View(notice);
        }

        //Admin/Notice/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Notice notice = db.Notices.Find(id);
                if (notice == null)
                {
                    return HttpNotFound();
                }               
                return View(notice);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(Notice notice)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(notice).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                return View(notice);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Notice/Update/Delete
        public ActionResult Delete(int id)
        {    
            if (Session["Admin"] != null)
            {
                Notice notice = db.Notices.Find(id);
                if (notice == null)
                {
                    return HttpNotFound();
                }
                db.Notices.Remove(notice);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}