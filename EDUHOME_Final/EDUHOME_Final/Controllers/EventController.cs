using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using EDUHOME_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUHOME_Final.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(string searchText)
        {
            VmEvent model = new VmEvent();
            model.Events = db.Events.Include("Category").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Name.Contains(searchText) : true)
                                                                 || (!string.IsNullOrEmpty(searchText) ? w.Venue.Contains(searchText) : true)
                                                                 || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)).ToList();
            model.Blogs = db.Blogs.Include("Category").Include("User").ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Categories = db.Categories.ToList();

            return View(model);
        }
        public ActionResult EventDetails(int Id)
        {
            VmEventSingle model = new VmEventSingle();
            model.Event = db.Events.Include("SpeakerEvents").Include("SpeakerEvents.Speaker").FirstOrDefault(p => p.Id == Id);
            model.Blogs = db.Blogs.Include("Category").Include("User").ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Categories = db.Categories.ToList();
       
            return View(model);
        }
    }
}