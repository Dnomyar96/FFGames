namespace FFGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameSessionUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGameSessions",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        GameSession_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.GameSession_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameSessions", t => t.GameSession_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.GameSession_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGameSessions", "GameSession_Id", "dbo.GameSessions");
            DropForeignKey("dbo.UserGameSessions", "User_Id", "dbo.Users");
            DropIndex("dbo.UserGameSessions", new[] { "GameSession_Id" });
            DropIndex("dbo.UserGameSessions", new[] { "User_Id" });
            DropTable("dbo.UserGameSessions");
        }
    }
}
