namespace SocNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PostTable", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.PostTable", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PostTable", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.PostTable", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
