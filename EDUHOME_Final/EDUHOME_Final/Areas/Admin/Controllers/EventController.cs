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
    public class EventController : Controller
    {
        // GET: Admin/Event
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(string searchText)
        {
            if (Session["Admin"] != null)
            {
                List<Event> events = db.Events.Include("Category").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Name.Contains(searchText) : true)
                                                                           || (!string.IsNullOrEmpty(searchText) ? w.Venue.Contains(searchText) : true)
                                                                           || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)).ToList();
                return View(events);
            }
            return RedirectToAction("Login", "Login");
        }
        
        //Admin/Event/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                Event eventy = db.Events.Find(Id);
                return View(eventy);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Event/Create
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
        public ActionResult Create(Event eventy)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Event Eventy = new Event();
                    if (eventy.ImageFile == null)
                    {
                        ModelState.AddModelError("", "Image is required");
                        ViewBag.Categories = db.Categories.ToList();
                    
                        return View(eventy);
                    }
                    else
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + eventy.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        eventy.ImageFile.SaveAs(imagePath);
                        Eventy.Image = imageName;
                    }
                    Eventy.Name = eventy.Name;
                    Eventy.StartDate = eventy.StartDate;
                    Eventy.EndDate = eventy.EndDate;
                    Eventy.Content = eventy.Content;
                    Eventy.Venue = eventy.Venue;
                    Eventy.CreatedDate = DateTime.Now;
                    Eventy.CategoryId = eventy.CategoryId;
                    
                    db.Events.Add(Eventy);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                 ViewBag.Categories = db.Categories.ToList();         
                 return View(eventy);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Event/update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Event eventy = db.Events.Find(id);
                if (eventy == null)
                {
                    return HttpNotFound();
                }               
                ViewBag.Categories = db.Categories.ToList();                
                return View(eventy);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Event eventy)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Event Eventy = db.Events.Find(eventy.Id);

                    if (eventy.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + eventy.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                        
                        string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Eventy.Image);
                        
                        eventy.ImageFile.SaveAs(imagePath);
                        System.IO.File.Delete(OldImagePath);
                        
                        Eventy.Image = imageName;
                    }
                    Eventy.CategoryId = eventy.CategoryId;
                    Eventy.Content = eventy.Content;
                    Eventy.EndDate = eventy.EndDate;
                    Eventy.StartDate = eventy.StartDate;
                    Eventy.Name = eventy.Name;
                    Eventy.Venue = eventy.Venue;
                    
                    db.Entry(Eventy).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Categories = db.Categories.ToList();          
                return View(eventy);
            }
            return RedirectToAction("Login", "Login");
        }
      
        //Admin/Event/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                Event eventy = db.Events.Find(id);
                if (eventy == null)
                {
                    return HttpNotFound();
                }                
                db.Events.Remove(eventy);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}