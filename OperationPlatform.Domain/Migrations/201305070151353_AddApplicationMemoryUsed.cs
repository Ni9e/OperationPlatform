namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationMemoryUsed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationMemoryUseds",
                c => new
                    {
                        NodeID = c.Int(nullable: false, identity: true),
                        NodeName = c.String(),
                        ApplicationName = c.String(),
                        ComponentName = c.String(),
                        AveragePercentMemory = c.Single(nullable: false),
                        PeakPercentMemory = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationMemoryUseds");
        }
    }
}
