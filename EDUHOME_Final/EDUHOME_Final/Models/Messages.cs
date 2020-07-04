using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Messages
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(500)]
        [Required]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}