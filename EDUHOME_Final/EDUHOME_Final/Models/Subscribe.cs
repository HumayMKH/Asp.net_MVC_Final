using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Subscribe
    {           
            public int Id { get; set; }

            [MaxLength(50)]
            [Required]
            public string Email { get; set; }

            public DateTime CreatedDate { get; set; }
    }
}