using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EDUHOME_Final.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        EduHomeContext db = new EduHomeContext();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<User> users = db.Users.ToList();
                return View(users);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/User/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                User users = db.Users.Find(Id);
                return View(users);
            }
            return RedirectToAction("Login", "Login");
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (db.Users.Any(u => u.Email == user.Email))
                    {
                        ModelState.AddModelError("Email", "This Email is already in use");
                        return View(user);
                    }
                    
                    if (db.Users.Any(u => u.Username == user.Username))
                    {
                        ModelState.AddModelError("Username", "This Username is already in use");
                        return View(user);
                    }
                    
                    User user1 = new User();
                    user1.Name = user.Name;
                    user1.Surname = user.Surname;
                    user1.Username = user.Username;
                    user1.Email = user.Email;
                    user1.Phone = user.Phone;
                    user1.CreatedDate = DateTime.Now;
                    
                    user1.Password = Crypto.HashPassword(user.Password);
                    
                    db.Users.Add(user1);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            return RedirectToAction("Login", "Login");
        }

        // GET: Admin/User/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }                
                return View(user);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    User User = db.Users.Find(user.Id);
                    User.Password = Crypto.HashPassword(user.Password);
                    User.Email = user.Email;
                    User.Name = user.Name;
                    User.Surname = user.Surname;
                    User.Phone = user.Phone;
                    User.Username = user.Username;
                    
                    db.Entry(User).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }       
                return View(user);
            }
            return RedirectToAction("Login", "Login");
        }

        // GET: Admin/User/Delete
        public ActionResult Delete(int id)
        { 
            if (Session["Admin"] != null)
            {
                User user = db.Users.Find(id);

                if (user == null)
                {
                    return HttpNotFound();
                }
                db.Users.Remove(user);
                db.SaveChanges();
               
                return RedirectToAction("Index");
             }
            return RedirectToAction("Login", "Login");
        }
    }
}