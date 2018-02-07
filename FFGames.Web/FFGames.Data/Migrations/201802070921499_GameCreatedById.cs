namespace FFGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameCreatedById : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSessions", "CreatedById", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameSessions", "CreatedById");
        }
    }
}
