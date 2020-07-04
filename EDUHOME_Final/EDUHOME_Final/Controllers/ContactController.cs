using EDUHOME_Final.DAL;
using EDUHOME_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUHOME_Final.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            VmContact model = new VmContact();
            model.Contact = db.Contacts.FirstOrDefault();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            return View(model);
        }
    }
}