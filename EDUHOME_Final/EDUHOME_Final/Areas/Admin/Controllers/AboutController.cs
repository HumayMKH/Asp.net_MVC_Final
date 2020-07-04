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
    public class AboutController : Controller
    {
        // GET: Admin/About
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<About> abouts = db.Abouts.ToList();
            return View(abouts);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/About/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                About abouts = db.Abouts.Find(Id);
                 return View(abouts);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/About/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(About about)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (about.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                
                        about.ImageFile.SaveAs(imagePath);
                        about.Image = imageName;
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Image is required");
                        return View(about);
                    }
                
                    db.Abouts.Add(about);
                    db.SaveChanges();
                
                    return RedirectToAction("Index");
                }

            return View(about);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/About/Uodate
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                 About about = db.Abouts.Find(id);
                 if (about == null)
                 {
                     return HttpNotFound();
                 }
                 
                 return View(about);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(About about)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    About About = db.Abouts.Find(about.Id);
                
                    if (about.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), About.Image);
                        System.IO.File.Delete(oldImagePath);
                
                        about.ImageFile.SaveAs(imagePath);
                        About.Image = imageName;
                    }
                    About.Content = about.Content;
                    About.Title = about.Title;
                    About.Video = about.Video;
                
                    db.Entry(About).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                    return View(about);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/About/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                 About about = db.Abouts.Find(id);
                 if (about == null)
                 {
                     return HttpNotFound();
                 }
                 
                 db.Abouts.Remove(about);
                 db.SaveChanges();
                 
                 return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}