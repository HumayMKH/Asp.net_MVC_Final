using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        public List<Course> Courses { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Event> Events { get; set; }
    }
}