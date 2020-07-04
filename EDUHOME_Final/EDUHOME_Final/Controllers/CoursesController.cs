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
    public class CoursesController : Controller
    {
        // GET: Courses
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(string searchText)
        {
            VmCourse model = new VmCourse();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Courses = db.Courses.Where(w => (!string.IsNullOrEmpty(searchText) ? w.Title.Contains(searchText) : true)
                                               || (!string.IsNullOrEmpty(searchText) ? w.CkEditorContent.Contains(searchText) : true)).ToList();

            return View(model);
        }

        // GET: CoursesDetails
        public ActionResult CourseDetails(int Id)
        {
            VmCourseSingle model = new VmCourseSingle();
            model.Course = db.Courses.Find(Id);
            model.Blogs = db.Blogs.Include("Category").Include("User").ToList();
            model.BannerImage = db.BannerImages.FirstOrDefault();
            model.Categories = db.Categories.ToList();
            return View(model);
        }
    }
}