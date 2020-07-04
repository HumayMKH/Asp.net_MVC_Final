using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmAbout
    {
        public About About { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TestimonialSlider> TestimonialSliders { get; set; }
        public List<Notice> Notices { get; set; }
        public BannerImage BannerImage { get; set; }
    }
}