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
    public class HomeController : Controller
    {
        // GET: Admin/Home
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"]!= null)
            {
                List<HomeSettings> homeSettings = db.HomeSettings.ToList();
                return View(homeSettings);
            }
            return RedirectToAction("Login", "Login");           
        }

        //Admin/Home/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                HomeSettings homeSettings = db.HomeSettings.Find(Id);
                return View(homeSettings);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Home/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                HomeSettings homeSetting = db.HomeSettings.Find(id);
                if (homeSetting == null)
                {
                    return HttpNotFound();
                }                
                return View(homeSetting);
            }
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        public ActionResult Update(HomeSettings homeSetting)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    HomeSettings HomeSettings = db.HomeSettings.Find(homeSetting.Id);

                    if (homeSetting.LogoFile != null)
                    {
                        string logoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + homeSetting.LogoFile.FileName;
                        string logoPath = Path.Combine(Server.MapPath("~/Uploads/"), logoName);
                    
                        string OldLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), HomeSettings.Logo);
                    
                        System.IO.File.Delete(OldLogoPath);
                    
                        homeSetting.LogoFile.SaveAs(logoPath);
                        HomeSettings.Logo = logoName;
                    }

                    if (homeSetting.FooterLogoFile != null)
                    {
                        string footerlogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + homeSetting.FooterLogoFile.FileName;
                        string footerlogoPath = Path.Combine(Server.MapPath("~/Uploads/"), footerlogoName);
                    
                        string OldfooterLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), HomeSettings.FooterLogo);
                    
                        System.IO.File.Delete(OldfooterLogoPath);
                    
                        homeSetting.FooterLogoFile.SaveAs(footerlogoPath);
                        HomeSettings.FooterLogo = footerlogoName;
                    }
                    HomeSettings.Address = homeSetting.Address;
                    HomeSettings.CopyRight = homeSetting.CopyRight;
                    HomeSettings.FooterContent = homeSetting.FooterContent;
                    HomeSettings.QuestionPhone = homeSetting.QuestionPhone;
                    HomeSettings.SiteEmail = homeSetting.SiteEmail;
                    HomeSettings.SiteLink = homeSetting.SiteLink;
                    HomeSettings.SitePhone1= homeSetting.SitePhone1;
                    HomeSettings.SitePhone2 = homeSetting.SitePhone2;
               
                    db.Entry(HomeSettings).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(homeSetting);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Home/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                HomeSettings homeSetting = db.HomeSettings.Find(id);
                if (homeSetting == null)
                {
                    return HttpNotFound();
                   
                }                
                db.HomeSettings.Remove(homeSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Home/MessageIndex
        public ActionResult MessageIndex()
        {
            if (Session["Admin"] != null)
            {
                List<Messages> message = db.Messages.ToList();
                return View(message);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Home/MessageDetails
        public ActionResult MessageIndexDetails(int Id)
        {
            if (Session["Admin"] != null)
            {
                Messages message = db.Messages.Find(Id);
                return View(message);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Home/MessageDelete
        public ActionResult MessageDelete(int id)
        {
            if (Session["Admin"] != null)
            {
                Messages message = db.Messages.Find(id);
                if (message == null)
                {
                    return HttpNotFound();
                }
                
                db.Messages.Remove(message);
                db.SaveChanges();
                return RedirectToAction("MessageIndex");
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Home/SubscribeIndex
        public ActionResult SubscribeIndex()
        {
            if (Session["Admin"] != null)
            {
                List<Subscribe> subscribes = db.Subscribes.ToList();
                return View(subscribes);
            }
             return RedirectToAction("Login", "Login");
        }
    }
}