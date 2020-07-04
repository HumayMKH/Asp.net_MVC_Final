using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string CkEditorContent { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}