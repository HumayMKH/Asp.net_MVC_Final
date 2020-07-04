using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmTeacher
    {
        public List< Teacher> Teachers { get; set; }
        public BannerImage BannerImage { get; set; }
        public int PageCount { get; set; }
        public int Currentpage { get; set; }
    }
}