using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Address1 { get; set; }
        [MaxLength(150)]
        [Required]
        public string Address2 { get; set; }
        [MaxLength(150)]
        [Required]
        public string Address3 { get; set; }
    }
}