namespace SocNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendsTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserA = c.String(),
                        UserB = c.String(),
                        IsFriends = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Sender = c.String(),
                        Receiver = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PostTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostContent = c.String(),
                        Comment = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserTable",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.UserTable", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.UserTable");
            DropForeignKey("dbo.PostTable", "ApplicationUser_Id", "dbo.UserTable");
            DropForeignKey("dbo.Notification", "ApplicationUser_Id", "dbo.UserTable");
            DropForeignKey("dbo.MessageTable", "ApplicationUser_Id", "dbo.UserTable");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.UserTable");
            DropForeignKey("dbo.UserTable", "ApplicationUser_Id", "dbo.UserTable");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.UserTable");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Notification", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserTable", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PostTable", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MessageTable", new[] { "ApplicationUser_Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.Notification");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.UserTable");
            DropTable("dbo.PostTable");
            DropTable("dbo.MessageTable");
            DropTable("dbo.FriendsTable");
        }
    }
}
