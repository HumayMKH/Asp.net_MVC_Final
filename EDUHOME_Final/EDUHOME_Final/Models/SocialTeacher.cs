using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class SocialTeacher
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Icon { get; set; }

        [MaxLength(150)]
        public string Link { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}