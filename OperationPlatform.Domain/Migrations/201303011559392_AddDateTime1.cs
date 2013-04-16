namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemoryUseds", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemoryUseds", "DateTime");
        }
    }
}
