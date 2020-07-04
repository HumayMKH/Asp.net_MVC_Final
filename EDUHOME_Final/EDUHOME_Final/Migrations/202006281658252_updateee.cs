namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Teachers", new[] { "Teacher_Id" });
            AddColumn("dbo.Teachers", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "CategoryId");
            AddForeignKey("dbo.Teachers", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Teachers", "Teacher_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Teacher_Id", c => c.Int());
            DropForeignKey("dbo.Teachers", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Teachers", new[] { "CategoryId" });
            DropColumn("dbo.Teachers", "CategoryId");
            CreateIndex("dbo.Teachers", "Teacher_Id");
            AddForeignKey("dbo.Teachers", "Teacher_Id", "dbo.Teachers", "Id");
        }
    }
}
