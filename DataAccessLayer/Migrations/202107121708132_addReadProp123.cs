namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReadProp123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsMessageRead", c => c.Boolean());
            AddColumn("dbo.Contacts", "IsContactRead", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsMessageRead");
            DropColumn("dbo.Contacts", "IsContactRead");
        }
    }
}
