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
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<Contact> contacts = db.Contacts.ToList();
                return View(contacts);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Contact/Details
        public ActionResult Details(int id)
        {
            if (Session["Admin"] != null)
            {
                Contact contact = db.Contacts.Find(id);
                return View(contact);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Category/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Category/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Contact contact = db.Contacts.Find(id);
                if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                return View(contact);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Category/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                Contact contact = db.Contacts.Find(id);
                if (contact == null)
                {
                    return HttpNotFound();
                }
                
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}