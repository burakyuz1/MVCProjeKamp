namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aylmue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
