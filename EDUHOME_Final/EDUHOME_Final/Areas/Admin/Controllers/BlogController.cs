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
    public class BlogController : Controller
    {
        // GET: Admin/Blog
        EduHomeContext db = new EduHomeContext();

        /* Blog CRUD */
        public ActionResult Index(string searchText)
        {
            if (Session["Admin"] != null)
            {
                List<Blog> blogs = db.Blogs.Include("Category").Include("User").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Title.Contains(searchText) : true)
                                                                                        || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)).ToList();

                return View(blogs);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Blog/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                Blog blog = db.Blogs.Find(Id);
                return View(blog);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Blog/Create
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
        public ActionResult Create(Blog blog)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Blog Blog = new Blog();
                    if (blog.ImageFile == null)
                    {
                         ModelState.AddModelError("", "Image is required");
                         ViewBag.Categories = db.Categories.ToList();
                         return View(blog);
                    }
                    else
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        blog.ImageFile.SaveAs(imagePath);
                        Blog.Image = imageName;
                    
                    }
                    Blog.ReadCount = blog.ReadCount;
                    Blog.Title = blog.Title;
                    Blog.CategoryId = blog.CategoryId;
                    Blog.Content = blog.Content;
                    Blog.CreatedDate = DateTime.Now;
                    Blog.UserId = (int)Session["LogginerId"];
                    
                    db.Blogs.Add(Blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Categories = db.Categories.ToList();
                return View(blog);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Blog/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Blog blog = db.Blogs.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
            
                 ViewBag.Categories = db.Categories.ToList();
                 return View(blog);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog blog)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Blog Blog = db.Blogs.Find(blog.Id);

                    if (blog.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Blog.Image);
                    
                        blog.ImageFile.SaveAs(imagePath);
                        System.IO.File.Delete(OldImagePath);
                    
                        Blog.Image = imageName;
                    }
                    Blog.ReadCount = blog.ReadCount;
                    Blog.Title = blog.Title;
                    Blog.CategoryId = blog.CategoryId;
                    Blog.Content = blog.Content;
                    
                    db.Entry(Blog).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Categories = db.Categories.ToList();
                return View(blog);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Blog/Delete
        public ActionResult Delete(int id)
        { 
            if (Session["Admin"] != null)
            {
                 Blog blog = db.Blogs.Find(id);
                 if (blog == null)
                 {
                     return HttpNotFound();
                 }
                 
                 db.Blogs.Remove(blog);
                 db.SaveChanges();
                 return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }

    }
}