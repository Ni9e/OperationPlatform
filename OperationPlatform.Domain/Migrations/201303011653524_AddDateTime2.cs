namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceNetworks", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceNetworks", "DateTime");
        }
    }
}
