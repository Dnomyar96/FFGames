namespace FFGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Session_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Session_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.Session_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Session_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSessions", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.UserSessions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GameSessions", "Session_Id", "dbo.Sessions");
            DropIndex("dbo.UserSessions", new[] { "Session_Id" });
            DropIndex("dbo.UserSessions", new[] { "User_Id" });
            DropIndex("dbo.GameSessions", new[] { "Session_Id" });
            DropTable("dbo.UserSessions");
            DropTable("dbo.Users");
            DropTable("dbo.Sessions");
            DropTable("dbo.GameSessions");
        }
    }
}
