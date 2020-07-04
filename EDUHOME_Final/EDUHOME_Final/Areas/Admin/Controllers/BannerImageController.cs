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
    public class BannerImageController : Controller
    {
        // GET: Admin/BannerImage
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<BannerImage> image = db.BannerImages.ToList();
            return View(image);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/BannerImage/Delete
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                BannerImage Image = db.BannerImages.Find(Id);
            return View(Image);
        }
        return RedirectToAction("Login", "Login");
    }

        //Admin/BannerImage/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(BannerImage image)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (image.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + image.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        image.ImageFile.SaveAs(imagePath);
                        image.Image = imageName;
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Image is required");
                        return View(image);
                    }
                    
                    db.BannerImages.Add(image);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }

                 return View(image);
            }
            return RedirectToAction("Login", "Login");

        }

        //Admin/BannerImage/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                BannerImage image = db.BannerImages.Find(id);
                if (image == null)
                {
                    return HttpNotFound();
                }
                
                return View(image);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(BannerImage image)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    BannerImage Image = db.BannerImages.Find(image.Id);

                    if (image.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + image.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Image.Image);
                        System.IO.File.Delete(oldImagePath);
                    
                        image.ImageFile.SaveAs(imagePath);
                        Image.Image = imageName;
                    }
                    
                    db.Entry(Image).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(image);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/BannerImage/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                 BannerImage image = db.BannerImages.Find(id);
                 if (image == null)
                 {
                     return HttpNotFound();
                 }
                 
                 db.BannerImages.Remove(image);
                 db.SaveChanges();
                 
                 return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}