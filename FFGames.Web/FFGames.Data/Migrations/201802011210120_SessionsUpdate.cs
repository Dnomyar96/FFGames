namespace FFGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Sessions", "DateCreated", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "DateCreated");
            DropColumn("dbo.Sessions", "CreatedBy");
        }
    }
}
