using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class HomeSlider
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        [MaxLength(300)]
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}