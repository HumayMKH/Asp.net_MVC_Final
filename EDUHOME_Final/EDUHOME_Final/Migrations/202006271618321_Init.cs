namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Image = c.String(maxLength: 150),
                        Video = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BannerImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        ReadCount = c.Int(nullable: false),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Image = c.String(maxLength: 150),
                        CkEditorContent = c.String(nullable: false, storeType: "ntext"),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.SpeakerEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        SpeakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.SpeakerId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 50),
                        Profession = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false, maxLength: 150),
                        Address2 = c.String(nullable: false, maxLength: 150),
                        Address3 = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionPhone = c.String(nullable: false, maxLength: 20),
                        SitePhone1 = c.String(nullable: false, maxLength: 20),
                        SitePhone2 = c.String(maxLength: 20),
                        Logo = c.String(maxLength: 150),
                        FooterLogo = c.String(maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 20),
                        SiteEmail = c.String(nullable: false, maxLength: 50),
                        SiteLink = c.String(nullable: false, maxLength: 150),
                        FooterContent = c.String(nullable: false, maxLength: 300),
                        CopyRight = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 20),
                        Link = c.String(maxLength: 150),
                        HomeSettingsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HomeSettings", t => t.HomeSettingsId, cascadeDelete: true)
                .Index(t => t.HomeSettingsId);
            
            CreateTable(
                "dbo.HomeSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 300),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Degree = c.String(maxLength: 100),
                        Experience = c.String(maxLength: 50),
                        Hobbies = c.String(maxLength: 100),
                        Faculty = c.String(maxLength: 150),
                        Email = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 20),
                        Skype = c.String(maxLength: 50),
                        LanguagePercent = c.Int(nullable: false),
                        DesignPercent = c.Int(nullable: false),
                        TeamLeaderPercent = c.Int(nullable: false),
                        InnovationPercent = c.Int(nullable: false),
                        DevelopmentPercent = c.Int(nullable: false),
                        CommunicationPercent = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.PositionId)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.SocialTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 20),
                        Link = c.String(maxLength: 150),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestimonialSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, maxLength: 500),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Education = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.SocialCompanies", "HomeSettingsId", "dbo.HomeSettings");
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.SpeakerEvents", "SpeakerId", "dbo.Speakers");
            DropForeignKey("dbo.SpeakerEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SocialTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "Teacher_Id" });
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropIndex("dbo.SocialCompanies", new[] { "HomeSettingsId" });
            DropIndex("dbo.SpeakerEvents", new[] { "SpeakerId" });
            DropIndex("dbo.SpeakerEvents", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "CategoryId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.TestimonialSliders");
            DropTable("dbo.Subscribes");
            DropTable("dbo.SocialTeachers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Positions");
            DropTable("dbo.Notices");
            DropTable("dbo.Messages");
            DropTable("dbo.HomeSliders");
            DropTable("dbo.SocialCompanies");
            DropTable("dbo.HomeSettings");
            DropTable("dbo.Contacts");
            DropTable("dbo.Users");
            DropTable("dbo.Speakers");
            DropTable("dbo.SpeakerEvents");
            DropTable("dbo.Events");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.BannerImages");
            DropTable("dbo.Abouts");
        }
    }
}
