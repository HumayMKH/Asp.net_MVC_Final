using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Blog> Blogs { get; set; }
        public object Crypto { get; internal set; }
    }
}