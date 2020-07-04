namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Slug", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Slug");
        }
    }
}
