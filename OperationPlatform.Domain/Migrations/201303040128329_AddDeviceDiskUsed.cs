namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeviceDiskUsed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceDiskUseds",
                c => new
                    {
                        NodeID = c.Int(nullable: false, identity: true),
                        NodeName = c.String(),
                        Volume = c.String(),
                        DiskSize = c.Single(nullable: false),
                        DiskSpaceUsed = c.Single(nullable: false),
                        PercentDiskSpaceUsed = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeviceDiskUseds");
        }
    }
}
