namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speakers", "CreatedDate");
        }
    }
}
