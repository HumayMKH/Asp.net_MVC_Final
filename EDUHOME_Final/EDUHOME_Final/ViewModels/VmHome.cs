using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmHome
    {
        public List<HomeSlider> HomeSliders { get; set; }
        public List<Teacher> Teachers { get; set; }
        public About About { get; set; }
        public List<Course> Courses { get; set; }
        public List<Notice> Notices { get; set; }
        public List<Event> Events { get; set; }
        public List<TestimonialSlider> TestimonialSliders { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}