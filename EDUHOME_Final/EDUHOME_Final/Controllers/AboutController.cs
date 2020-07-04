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
    public class AboutController : Controller
    {
        // GET: About
        EduHomeContext db = new EduHomeContext();

        public ActionResult Index()
        {
            VmAbout model = new VmAbout();
            model.About = db.Abouts.FirstOrDefault();
            model.Teachers = db.Teachers.Include("Position").Include("SocialTeachers").OrderBy(o => o.Id).Take(4).ToList();
            model.Notices = db.Notices.ToList();
            model.TestimonialSliders = db.TestimonialSliders.ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            return View(model);
        }
    }
}