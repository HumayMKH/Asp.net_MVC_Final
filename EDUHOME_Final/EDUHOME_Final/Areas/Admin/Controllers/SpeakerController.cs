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
    public class SpeakerController : Controller
    {
        // GET: Admin/Speaker
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<Speaker> speakers = db.Speakers.ToList();
                return View(speakers);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Speaker/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                Speaker Speaker = db.Speakers.Find(Id);
                return View(Speaker);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Speaker/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(Speaker speaker)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (speaker.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        speaker.ImageFile.SaveAs(imagePath);
                        speaker.Image = imageName;
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Image is required");
                        return View(speaker);
                    }                    
                    speaker.CreatedDate = DateTime.Now;
                    
                    db.Speakers.Add(speaker);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                return View(speaker);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Speaker/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Speaker speaker = db.Speakers.Find(id);
                if (speaker == null)
                {
                    return HttpNotFound();
                }                
                return View(speaker);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(Speaker speaker)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                Speaker Speaker = db.Speakers.Find(speaker.Id);

                    if (speaker.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Speaker.Image);
                        System.IO.File.Delete(oldImagePath);
                    
                        speaker.ImageFile.SaveAs(imagePath);
                        Speaker.Image = imageName;
                    }
                    Speaker.Name = speaker.Name;
                    Speaker.Profession = speaker.Profession;
                    
                    db.Entry(Speaker).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(speaker);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Speaker/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                Speaker speaker = db.Speakers.Find(id);
                if (speaker == null)
                {
                    return HttpNotFound();
                }                
                db.Speakers.Remove(speaker);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}