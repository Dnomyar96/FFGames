namespace FFGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterTokens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(unicode: false),
                        AmountAllowed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "RegisterToken_Id", c => c.Int());
            CreateIndex("dbo.Users", "RegisterToken_Id");
            AddForeignKey("dbo.Users", "RegisterToken_Id", "dbo.RegisterTokens", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RegisterToken_Id", "dbo.RegisterTokens");
            DropIndex("dbo.Users", new[] { "RegisterToken_Id" });
            DropColumn("dbo.Users", "RegisterToken_Id");
            DropTable("dbo.RegisterTokens");
        }
    }
}
