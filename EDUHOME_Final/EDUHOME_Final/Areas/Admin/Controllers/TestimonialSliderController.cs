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
    public class TestimonialSliderController : Controller
    {
        // GET: Admin/TestimonialSlider
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<TestimonialSlider> sliders = db.TestimonialSliders.ToList();
                return View(sliders);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/TestimonialSlider/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                TestimonialSlider Slider = db.TestimonialSliders.Find(Id);
                return View(Slider);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/TestimonialSlider/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }
  
        [HttpPost]
        public ActionResult Create(TestimonialSlider slider)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (slider.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        slider.ImageFile.SaveAs(imagePath);
                        slider.Image = imageName;
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Image is required");
                        return View(slider);
                    }                    
                    slider.CreatedDate = DateTime.Now;
                    
                    db.TestimonialSliders.Add(slider);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                return View(slider);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/TestimonialSlider/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                TestimonialSlider slider = db.TestimonialSliders.Find(id);

                if (slider == null)
                {
                    return HttpNotFound();
                }                
                return View(slider);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(TestimonialSlider slider)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                { 
                    TestimonialSlider Slider = db.TestimonialSliders.Find(slider.Id);
            
                    if (slider.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Slider.Image);
                        System.IO.File.Delete(oldImagePath);
                    
                        slider.ImageFile.SaveAs(imagePath);
                        Slider.Image = imageName;
                    }
                    Slider.Fullname = slider.Fullname;
                    Slider.Content = slider.Content;
                    Slider.Education = slider.Education;
                    
                    db.Entry(Slider).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(slider);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/TestimonialSlider/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                TestimonialSlider slider = db.TestimonialSliders.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }              
                db.TestimonialSliders.Remove(slider);
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}
