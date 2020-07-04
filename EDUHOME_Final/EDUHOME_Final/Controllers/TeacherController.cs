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
    public class TeacherController : Controller
    {
        // GET: Teacher
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(int page=1)
        {
           VmTeacher model = new VmTeacher();
           model.Teachers = db.Teachers.Include("Position").Include("SocialTeachers").OrderByDescending(o => o.Id).Skip((page - 1) * 4).Take(4).ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.PageCount = Convert.ToInt32(Math.Ceiling(db.Blogs.Count() / 4.0));
            model.Currentpage = page;
            return View(model);
        }
        public ActionResult TeacherDetails(int Id)
        {
            VmTeacherSingle model = new VmTeacherSingle();

            model.Teacher = db.Teachers.Include("Position").Include("SocialTeachers").FirstOrDefault(p => p.Id == Id);
            model.Blogs = db.Blogs.Include("Category").Include("User").ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Categories = db.Categories.ToList();
            
            return View(model);
        }
    }
}