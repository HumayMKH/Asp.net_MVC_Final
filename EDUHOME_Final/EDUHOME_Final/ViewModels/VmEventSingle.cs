using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmEventSingle
    {
        public Event Event { get; set; }
        public BannerImage BannerImage { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
        public List<Speaker> Speakers { get; set; }
       
    }
}