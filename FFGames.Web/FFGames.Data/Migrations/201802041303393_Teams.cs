namespace FFGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        GameSession_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameSessions", t => t.GameSession_Id)
                .Index(t => t.GameSession_Id);
            
            CreateTable(
                "dbo.TeamUsers",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.User_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.GameSessions", "TeamSize", c => c.Int(nullable: false));
            AddColumn("dbo.GameSessions", "TeamAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TeamUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "GameSession_Id", "dbo.GameSessions");
            DropIndex("dbo.TeamUsers", new[] { "User_Id" });
            DropIndex("dbo.TeamUsers", new[] { "Team_Id" });
            DropIndex("dbo.Teams", new[] { "GameSession_Id" });
            DropColumn("dbo.GameSessions", "TeamAmount");
            DropColumn("dbo.GameSessions", "TeamSize");
            DropTable("dbo.TeamUsers");
            DropTable("dbo.Teams");
        }
    }
}
