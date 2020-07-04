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
    public class SpeakerEventController : Controller
    {
        // GET: Admin/SpeakerEvent
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<SpeakerEvent> speakerEvents = db.SpeakerEvents.Include("Speaker").Include("Event").ToList();
                return View(speakerEvents);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SpeakerEvent/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Speaker = db.Speakers.ToList();
                ViewBag.Event = db.Events.ToList();

                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(SpeakerEvent speakerEvent)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.SpeakerEvents.Add(speakerEvent);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                ViewBag.Speaker = db.Speakers.ToList();
                ViewBag.Event = db.Events.ToList();

                return View(speakerEvent);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SpeakerEvent/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                SpeakerEvent speakerEvent = db.SpeakerEvents.Find(id);

                if (speakerEvent == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Speaker = db.Speakers.ToList();
                ViewBag.Event = db.Events.ToList();

                return View(speakerEvent);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(SpeakerEvent speakerEvent)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(speakerEvent).State = EntityState.Modified;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Speaker = db.Speakers.ToList();
                ViewBag.Event = db.Events.ToList();

                return View(speakerEvent);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/SpeakerEvent/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                SpeakerEvent speakerEvent = db.SpeakerEvents.Find(id);
                if (speakerEvent == null)
                {
                    return HttpNotFound();
                }                
                db.SpeakerEvents.Remove(speakerEvent);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}