namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationCPUUsed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationCPUUseds",
                c => new
                    {
                        NodeID = c.Int(nullable: false, identity: true),
                        NodeName = c.String(),
                        ApplicationName = c.String(),
                        ComponentName = c.String(),
                        AveragePercentCPU = c.Single(nullable: false),
                        PeakPercentCPU = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.NodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationCPUUseds");
        }
    }
}
