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
    public class HomeSliderController : Controller
    {
        // GET: Admin/HomeSlider
        EduHomeContext db = new EduHomeContext();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<HomeSlider> homeSliders = db.HomeSliders.ToList();
                return View(homeSliders);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/HomeSlider/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                HomeSlider homeSlider = db.HomeSliders.Find(Id);
                return View(homeSlider);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/HomeSlider/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(HomeSlider homeSlider)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (homeSlider.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + homeSlider.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        homeSlider.ImageFile.SaveAs(imagePath);
                        homeSlider.Image = imageName;
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Image is required");
                        return View(homeSlider);
                    }
                    homeSlider.CreatedDate = DateTime.Now;
                    
                    db.HomeSliders.Add(homeSlider);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Login", "Login");
            }
            return View(homeSlider);
        }

        //Admin/HomeSlider/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                HomeSlider homeslider = db.HomeSliders.Find(id);
                if (homeslider == null)
                {
                    return HttpNotFound();
                }                
                return View(homeslider);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(HomeSlider homeSlider)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                HomeSlider HomeSlider = db.HomeSliders.Find(homeSlider.Id);
                    if (homeSlider.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + homeSlider.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), HomeSlider.Image);
                        System.IO.File.Delete(oldImagePath);
                    
                        homeSlider.ImageFile.SaveAs(imagePath);
                        HomeSlider.Image = imageName;
                    }
                    HomeSlider.Title = homeSlider.Title;
                    HomeSlider.Content = homeSlider.Content;
                    
                    db.Entry(HomeSlider).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(homeSlider);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/HomeSlider/Delete
        public ActionResult Delete(int Id)
        {
            if (Session["Admin"] != null)
            {
                HomeSlider homeSlider = db.HomeSliders.Find(Id);
                if (homeSlider == null)
                {
                    return HttpNotFound();
                }                
                db.HomeSliders.Remove(homeSlider);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}