using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmSearch
    {
        public List<Blog> Blogs { get; set; }
        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}