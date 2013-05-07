namespace OperationPlatform.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationAvailability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationAvailabilities",
                c => new
                    {
                        NodeID = c.Int(nullable: false, identity: true),
                        NodeName = c.String(),
                        ApplicationName = c.String(),
                        AverangeApplicationAvailability = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationAvailabilities");
        }
    }
}
