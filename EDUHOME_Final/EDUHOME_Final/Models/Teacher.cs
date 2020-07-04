using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Teacher
    {
        public int Id { get; set; }
       
        [MaxLength(50)]
        [Required]
        public string Fullname { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }
        [MaxLength(100)]
        public string Degree { get; set; }
        [MaxLength(50)]
        public string Experience { get; set; }
        [MaxLength(100)]
        public string Hobbies { get; set; }
        [MaxLength(150)]
        public string Faculty { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Skype { get; set; }
        public int LanguagePercent { get; set; }
        public int DesignPercent { get; set; }
        public int TeamLeaderPercent { get; set; }
        public int InnovationPercent { get; set; }
        public int DevelopmentPercent { get; set; }
        public int CommunicationPercent { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<SocialTeacher> SocialTeachers { get; set; }
    }
}