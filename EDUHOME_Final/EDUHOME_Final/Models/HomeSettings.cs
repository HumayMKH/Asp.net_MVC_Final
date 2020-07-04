using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.Models
{
    public class HomeSettings
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string QuestionPhone { get; set; }
        [MaxLength(20)]
        [Required]
        public string SitePhone1 { get; set; }        
        [MaxLength(20)]
        public string SitePhone2 { get; set; }
        [MaxLength(150)]
        public string Logo { get; set; }
        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }
        [MaxLength(150)]
        public string FooterLogo { get; set; }
        [NotMapped]
        public HttpPostedFileBase FooterLogoFile { get; set; }
        [MaxLength(20)]
        [Required]
        public string Address { get; set; }
        [MaxLength(50)]
        [Required]
        public string SiteEmail { get; set; }
        [MaxLength(150)]
        [Required]
        public string SiteLink { get; set; }
        [MaxLength(300)]
        [Required]
        public string FooterContent { get; set; }
        [MaxLength(300)]
        [Required]
        public string CopyRight { get; set; }
        public List<SocialCompany> SocialCompany { get; set; }
    }
}