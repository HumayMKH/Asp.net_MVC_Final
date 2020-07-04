using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using EDUHOME_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EDUHOME_Final.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(string searchText,int page = 1)
        {
            VmBlog model = new VmBlog();
            model.Blogs = db.Blogs.Include("Category").Include("User").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Title.Contains(searchText) : true)
                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)).ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Categories = db.Categories.ToList();
            model.PageCount =Convert.ToInt32( Math.Ceiling(db.Blogs.Count() / 4.0));
            model.Currentpage = page;

            return View(model);
        }

        // GET: BlogDetails
        public ActionResult BlogDetails(int Id,Blog blog)
        {
            VmBlogSingle model = new VmBlogSingle();
            model.Blog = db.Blogs.Include("Category").Include("User").FirstOrDefault(b=>b.Id==Id);            
            Blog Blog = db.Blogs.Find(blog.Id);
            model.Blog.ReadCount++;
            db.Entry(Blog).State = EntityState.Modified;
            db.SaveChanges();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Categories = db.Categories.ToList();
            model.Blogs = db.Blogs.Include("Category").Include("User").ToList();
          
            return View(model);           
        }

        // GET: BlogCreate
        public ActionResult BlogCreate(Blog blog)
        {
            if (Session["Logginer"] != null)
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
                    Blog.CategoryId = blog.CategoryId;
                    Blog.UserId = (int)Session["LogginerId"];
                    Blog.Title = blog.Title;
                    Blog.ReadCount = blog.ReadCount;
                    Blog.Content = blog.Content;
                    Blog.CreatedDate = DateTime.Now;

                    db.Blogs.Add(Blog);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                ViewBag.Categories = db.Categories.ToList();
                return View(blog);

            }
            else
            {
                Session["Emptyuser"] = true;
            }
            return RedirectToAction("Login", "Home");         
        }
    }
    
}