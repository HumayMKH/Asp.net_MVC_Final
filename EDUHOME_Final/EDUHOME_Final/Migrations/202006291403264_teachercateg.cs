namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachercateg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Teachers", new[] { "CategoryId" });
            DropColumn("dbo.Teachers", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "CategoryId");
            AddForeignKey("dbo.Teachers", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
