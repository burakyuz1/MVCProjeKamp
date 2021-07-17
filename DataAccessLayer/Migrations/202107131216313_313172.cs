namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _313172 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsContactRead", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsContactRead");
        }
    }
}
