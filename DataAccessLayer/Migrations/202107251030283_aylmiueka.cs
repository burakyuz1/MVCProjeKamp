namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aylmiueka : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WriterRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Writers", "WriterStatus");
        }
    }
}
