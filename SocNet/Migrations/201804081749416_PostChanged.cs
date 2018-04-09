namespace SocNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostTable", "UserNameOfReceiver", c => c.String());
            AddColumn("dbo.PostTable", "UserNameOfSender", c => c.String());
            DropColumn("dbo.PostTable", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostTable", "Comment", c => c.String());
            DropColumn("dbo.PostTable", "UserNameOfSender");
            DropColumn("dbo.PostTable", "UserNameOfReceiver");
        }
    }
}
