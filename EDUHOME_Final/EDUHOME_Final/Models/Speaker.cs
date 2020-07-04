using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Profession { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SpeakerEvent> SpeakerEvents { get; set; }
    }
}