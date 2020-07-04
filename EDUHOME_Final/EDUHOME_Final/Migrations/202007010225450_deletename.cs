namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletename : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SocialCompanies", "Name");
            DropColumn("dbo.SocialTeachers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialTeachers", "Name", c => c.String(maxLength: 30));
            AddColumn("dbo.SocialCompanies", "Name", c => c.String(maxLength: 30));
        }
    }
}
