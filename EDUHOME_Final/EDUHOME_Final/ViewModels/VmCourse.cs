﻿using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmCourse
    {
        public List<Course> Courses { get; set; }
        public BannerImage BannerImage { get; set; }
    }
}