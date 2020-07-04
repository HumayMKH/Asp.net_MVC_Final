using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using EDUHOME_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace EDUHOME_Final.Controllers
{
    public class HomeController : Controller
    { 
        EduHomeContext db = new EduHomeContext();

        //Home/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
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

                return RedirectToAction("Login", "Home");
            }
            return View(user);
        }

       //Home/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VmLogin login)
        {
            if (ModelState.IsValid)
            {
                User user1 = db.Users.FirstOrDefault(u => u.Username == login.Username);

                if (user1 != null)
                {
                    if (Crypto.VerifyHashedPassword(user1.Password, login.Password))
                    {
                        Session["Logginer"] = true;
                        Session["LogginerId"] = user1.Id;

                        return RedirectToAction("BlogCreate", "Blog");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password!");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Incorrect Username!");
                    return View(login);
                }
            }
            return View(login);
        }

        //Home/Logout
        public ActionResult Logout()
        {
            Session["Logginer"] = null;
            Session["LogginerId"] = null;

            return RedirectToAction("Login", "Home");
        }
    
        //Home/FullSearch
        public ActionResult Search(string searchText)
        {
            VmSearch model = new VmSearch();
            model.Courses = model.Courses = db.Courses.Where(w => (!string.IsNullOrEmpty(searchText) ? w.Title.Contains(searchText) : true)
                                                               || (!string.IsNullOrEmpty(searchText) ? w.CkEditorContent.Contains(searchText) : true)).ToList();
           
            model.Events = db.Events.Include("Category").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Name.Contains(searchText) : true)
                                                                 || (!string.IsNullOrEmpty(searchText) ? w.Venue.Contains(searchText) : true)
                                                                 || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)).ToList();
                                                                 
            model.Teachers = db.Teachers.Include("Position").Include("SocialTeachers").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Fullname.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Degree.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Experience.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Faculty.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Hobbies.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Skype.Contains(searchText) : true)
                                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Email.Contains(searchText) : true)).ToList();

            model.Blogs = db.Blogs.Include("Category").Include("User").Where(w => (!string.IsNullOrEmpty(searchText) ? w.Title.Contains(searchText) : true)
                                                                               || (!string.IsNullOrEmpty(searchText) ? w.Content.Contains(searchText) : true)).ToList();
            return View(model);
        }

        //Home/Index
        public ActionResult Index()
        {
            VmHome model = new VmHome();
            model.HomeSliders = db.HomeSliders.ToList();
            model.About = db.Abouts.FirstOrDefault();
            model.Blogs = db.Blogs.Include("User").OrderBy(o => o.Id).Take(3).ToList();
            model.Courses = db.Courses.OrderBy(o => o.Id).Take(3).ToList();
            model.Events = db.Events.OrderBy(o => o.Id).Take(4).ToList();
            model.Notices = db.Notices.ToList();
            model.Teachers = db.Teachers.Include("SocialTeachers").Include("Position").OrderBy(o=>o.Id).Take(4).ToList();

            model.TestimonialSliders = db.TestimonialSliders.ToList();
            return View(model);
        }

        //Home/Subscribe
        [HttpPost]
        public ActionResult Subscribe(VmSubscribe subscribe)
        {
            if (string.IsNullOrEmpty(subscribe.Email))
            {
                Session["EmptyMail"] = true;
                if (subscribe.Page == "Home")
                {
                    return RedirectToAction("Index", "Home");
                }

                else if (subscribe.Page == "About")
                {
                    return RedirectToAction("Index", "About");
                }
                else if (subscribe.Page == "Contact")
                {
                    return RedirectToAction("Index", "Contact");
                }
                else if (subscribe.Page == "Blog")
                {
                    return RedirectToAction("Index", "Blog");
                }
                else if (subscribe.Page == "Courses")
                {
                    return RedirectToAction("Index", "Courses");
                }
                else if (subscribe.Page == "Event")
                {
                    return RedirectToAction("Index", "Event");
                }
                else if (subscribe.Page == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else if (subscribe.Page == "BlogDetails")
                {
                    return RedirectToAction("BlogDetails", "Blog", new { Id = subscribe.blogid });
                }
                else if (subscribe.Page == "CourseDetails")
                {
                    return RedirectToAction("CourseDetails", "Courses", new { Id = subscribe.courseId});
                }
                else if (subscribe.Page == "EventDetails")
                {
                    return RedirectToAction("EventDetails", "Event", new { Id = subscribe.eventid });
                }
                else 
                {
                    return RedirectToAction("TeacherDetails", "Teacher", new { Id = subscribe.teacherId });
                }
            }
            Subscribe Subscribe = new Subscribe();
            Subscribe.Email = subscribe.Email;
            Subscribe.CreatedDate = DateTime.Now;

            db.Subscribes.Add(Subscribe);
            db.SaveChanges();

            Session["SuccessfullSubscribe"] = true;

            if (subscribe.Page == "Home")
            {
                return RedirectToAction("Index", "Home");
            }

            else if (subscribe.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (subscribe.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else if (subscribe.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (subscribe.Page == "Courses")
            {
                return RedirectToAction("Index", "Courses");
            }
            else if (subscribe.Page == "Event")
            {
                return RedirectToAction("Index", "Event");
            }
            else if (subscribe.Page == "Teacher")
            {
                return RedirectToAction("Index", "Teacher");
            }
            else if (subscribe.Page == "BlogDetails")
            {
                return RedirectToAction("BlogDetails", "Blog", new { Id = subscribe.blogid });
            }
            else if (subscribe.Page == "CourseDetails")
            {
                return RedirectToAction("CourseDetails", "Courses", new { Id = subscribe.courseId });
            }
            else if (subscribe.Page == "EventDetails")
            {
                return RedirectToAction("EventDetails", "Event", new { Id = subscribe.eventid });
            }
            else
            {
                return RedirectToAction("TeacherDetails", "Teacher", new { Id = subscribe.teacherId });
            }
        }
    }    
}