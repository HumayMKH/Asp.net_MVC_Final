using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.ViewModels
{
    public class VmSubscribe
    {
        public string Email { get; set; }

        public string Page { get; set; }

        public int? courseId { get; set; }
        public int? teacherId { get; set; }
        public int? blogid { get; set; }
        public int? eventid { get; set; }
    }
}