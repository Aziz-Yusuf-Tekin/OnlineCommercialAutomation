namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargoTracking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailID = c.Int(nullable: false, identity: true),
                        CargoComment = c.String(maxLength: 300, unicode: false),
                        CargoTrackingCode = c.String(maxLength: 10, unicode: false),
                        Sender = c.String(maxLength: 30, unicode: false),
                        Buyer = c.String(maxLength: 30, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailID);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingID = c.Int(nullable: false, identity: true),
                        CargoTrackingCode = c.String(maxLength: 10, unicode: false),
                        CargoTrackingComment = c.String(maxLength: 300, unicode: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
