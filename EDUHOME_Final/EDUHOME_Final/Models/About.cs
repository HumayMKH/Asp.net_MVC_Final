using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDUHOME_Final.Models
{
    public class About
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(250)]
        public string Video { get; set; }
    }
}