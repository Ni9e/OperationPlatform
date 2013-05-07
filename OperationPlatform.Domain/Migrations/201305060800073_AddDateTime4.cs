namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationCPUUseds", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationCPUUseds", "DateTime");
        }
    }
}
