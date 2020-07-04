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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<Category> categories = db.Categories.ToList();
                return View(categories);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Category/Details
        public ActionResult Details(int id)
        {
            if (Session["Admin"] != null)
            {
                Category category = db.Categories.Find(id);
                return View(category);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Category/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (Session["Admin"] != null)
            {

                if (ModelState.IsValid)
                {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                return View(category);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Category/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Category category = db.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            return RedirectToAction("Login", "Login");
        }
        
        //Admin/Category/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                Category category = db.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                db.Categories.Remove(category);
                db.SaveChanges();
            return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}