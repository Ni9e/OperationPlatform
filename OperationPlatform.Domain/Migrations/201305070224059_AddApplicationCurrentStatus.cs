namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationCurrentStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationCurrentStatus",
                c => new
                    {
                        NodeID = c.Int(nullable: false, identity: true),
                        NodeName = c.String(),
                        ApplicationName = c.String(),
                        ApplicationStatus = c.String(),
                        ComponentName = c.String(),
                        CompinentStatus = c.String(),
                    })
                .PrimaryKey(t => t.NodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationCurrentStatus");
        }
    }
}
