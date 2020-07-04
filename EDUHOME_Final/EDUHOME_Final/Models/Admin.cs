using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class AdmiNLogin
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }
        public object Crypto { get; internal set; }
    }
}