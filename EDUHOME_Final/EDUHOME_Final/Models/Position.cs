using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Position
    {
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}