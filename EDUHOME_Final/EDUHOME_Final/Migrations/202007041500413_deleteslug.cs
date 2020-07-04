namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteslug : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teachers", "Slug");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Slug", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
