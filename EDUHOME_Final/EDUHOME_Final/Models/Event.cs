using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Event
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Venue { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<SpeakerEvent> SpeakerEvents { get; set; }
    }
}