namespace EDUHOME_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmiNLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdmiNLogins");
        }
    }
}
