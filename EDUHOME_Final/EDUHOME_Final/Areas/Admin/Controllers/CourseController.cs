using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUHOME_Final.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        // GET: Admin/Course
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(string searchText)
        {
            if (Session["Admin"] != null)
            {
                List<Course> course = db.Courses.Where(w => (!string.IsNullOrEmpty(searchText) ? w.Title.Contains(searchText) : true)
                                                         || (!string.IsNullOrEmpty(searchText) ? w.CkEditorContent.Contains(searchText) : true)).ToList();  
                return View(course);
            }
            return RedirectToAction("Login", "Login");
        }
        
        //Admin/Course/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                Course course = db.Courses.Find(Id);
                return View(course);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Course/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Categories = db.Categories.ToList();
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Course course)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Course Course = new Course();

                    if (course.ImageFile == null)
                    {
                        ModelState.AddModelError("", "Image is required");
                        ViewBag.Categories = db.Categories.ToList();
                    
                        return View(course);
                    }
                    else
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        course.ImageFile.SaveAs(imagePath);
                        Course.Image = imageName;
                    }
                    Course.Title = course.Title;
                    Course.CkEditorContent = course.CkEditorContent;                    
                    Course.CategoryId = course.CategoryId;
                    
                    db.Courses.Add(Course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                 ViewBag.Categories = db.Categories.ToList();
                 return View(course);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Course/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }               
                ViewBag.Categories = db.Categories.ToList();
                return View(course);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Course course)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Course Course = db.Courses.Find(course.Id);

                    if (course.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                        
                        string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Course.Image);
                        
                        course.ImageFile.SaveAs(imagePath);
                        System.IO.File.Delete(OldImagePath);
                        
                        Course.Image = imageName;
                    }
                    Course.Title = course.Title;
                    Course.CkEditorContent = course.CkEditorContent;                    
                    Course.CategoryId = course.CategoryId;
                    
                    db.Entry(Course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Categories = db.Categories.ToList();         
                return View(course);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Course/Delete
        public ActionResult Delete(int id)
        {   
            if (Session["Admin"] != null)
            {
              Course course = db.Courses.Find(id);
                 if (course == null)
                 {
                     return HttpNotFound();
                 }                
                 db.Courses.Remove(course);
                 db.SaveChanges();
                 
                 return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}