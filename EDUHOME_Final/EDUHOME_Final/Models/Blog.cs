using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        public int ReadCount { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }
    }
}