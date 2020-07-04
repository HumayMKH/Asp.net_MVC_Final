using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Notice
    {
        public int Id { get; set; }
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}