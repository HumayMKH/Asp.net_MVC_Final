using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EDUHOME_Final.DAL
{
    public class EduHomeContext:DbContext
    {
        public EduHomeContext() : base("EduHomeSC")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AdmiNLogin> AdmiNLogins { get; set; }
        public DbSet<BannerImage> BannerImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<HomeSettings> HomeSettings { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SocialCompany> SocialCompanies { get; set; }
        public DbSet<SocialTeacher> SocialTeachers { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TestimonialSlider> TestimonialSliders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}