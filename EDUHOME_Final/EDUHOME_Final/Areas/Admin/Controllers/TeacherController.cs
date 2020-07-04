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
    public class TeacherController : Controller
    {
        // GET: Admin/Teacher
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<Teacher> teachers = db.Teachers.ToList();
                return View(teachers);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Teacher/Details
        public ActionResult Details(int Id)
        {
            if (Session["Admin"] != null)
            {
                Teacher teacher = db.Teachers.Find(Id);
                return View(teacher);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Teacher/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Positions = db.Positions.ToList();
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        
        public ActionResult Create(Teacher teacher)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Teacher Teacher = new Teacher();
                    if (teacher.ImageFile == null)
                    {
                        ModelState.AddModelError("", "Image is required");
                      
                       ViewBag.Positions = db.Positions.ToList();
                        return View(teacher);
                    }
                    else
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        teacher.ImageFile.SaveAs(imagePath);
                        Teacher.Image = imageName;
                    }
                    Teacher.Fullname = teacher.Fullname;                    
                    Teacher.CommunicationPercent = teacher.CommunicationPercent;
                    Teacher.Content = teacher.Content;
                    Teacher.Degree = teacher.Degree;
                    Teacher.DesignPercent = teacher.DesignPercent;
                    Teacher.DevelopmentPercent = teacher.DevelopmentPercent;
                    Teacher.Email = teacher.Email;
                    Teacher.Experience = teacher.Experience;
                    Teacher.Faculty = teacher.Faculty;
                    Teacher.Hobbies = teacher.Hobbies;
                    Teacher.InnovationPercent = teacher.InnovationPercent;
                    Teacher.LanguagePercent = teacher.LanguagePercent;
                    Teacher.Phone = teacher.Phone;
                    Teacher.Skype = teacher.Skype;
                    Teacher.TeamLeaderPercent = teacher.TeamLeaderPercent;
                    Teacher.PositionId = teacher.PositionId;
                                     
                    db.Teachers.Add(Teacher);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                ViewBag.Positions = db.Positions.ToList();
                return View(teacher);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Teacher/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Teacher teacher = db.Teachers.Find(id);
                if (teacher == null)
                {
                    return HttpNotFound();
                }               
                ViewBag.Positions = db.Positions.ToList();
                return View(teacher);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        
        public ActionResult Update(Teacher teacher)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    Teacher Teacher = db.Teachers.Find(teacher.Id);
                    
                    if (teacher.ImageFile != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    
                        string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Teacher.Image);
                    
                        teacher.ImageFile.SaveAs(imagePath);
                        System.IO.File.Delete(OldImagePath);
                    
                        Teacher.Image = imageName;
                    }
                    Teacher.Fullname = teacher.Fullname;
                    
                    Teacher.CommunicationPercent = teacher.CommunicationPercent;
                    Teacher.Content = teacher.Content;
                    Teacher.Degree = teacher.Degree;
                    Teacher.DesignPercent = teacher.DesignPercent;
                    Teacher.DevelopmentPercent = teacher.DevelopmentPercent;
                    Teacher.Email = teacher.Email;
                    Teacher.Experience = teacher.Experience;
                    Teacher.Faculty = teacher.Faculty;
                    Teacher.Hobbies = teacher.Hobbies;
                    Teacher.InnovationPercent = teacher.InnovationPercent;
                    Teacher.LanguagePercent = teacher.LanguagePercent;
                    Teacher.Phone = teacher.Phone;
                    Teacher.Skype = teacher.Skype;
                    Teacher.TeamLeaderPercent = teacher.TeamLeaderPercent;
                    Teacher.PositionId = teacher.PositionId;                    
                    
                    db.Entry(Teacher).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }          
                ViewBag.Positions = db.Positions.ToList();
                return View(teacher);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Teacher/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                Teacher teacher = db.Teachers.Find(id);
                if (teacher == null)
                {
                    return HttpNotFound();
                }                
                db.Teachers.Remove(teacher);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}