namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Availabilities", "DateTime");
        }
    }
}
