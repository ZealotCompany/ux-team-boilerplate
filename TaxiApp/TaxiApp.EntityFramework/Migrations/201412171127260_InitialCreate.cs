namespace TaxiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(),
                        DriverId = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.DriverId)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Experience = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        LicenseNumber = c.String(),
                        ServiceType = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        UserName = c.String(),
                        Salt = c.String(),
                        HashedPassword = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandTypeId = c.Int(),
                        CarTypeId = c.Int(),
                        ProductionYear = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BrandTypes", t => t.BrandTypeId)
                .ForeignKey("dbo.CarTypes", t => t.CarTypeId)
                .Index(t => t.BrandTypeId)
                .Index(t => t.CarTypeId);
            
            CreateTable(
                "dbo.BrandTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        SuggestedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationFrom_City = c.String(),
                        LocationFrom_Street = c.String(),
                        LocationFrom_Place = c.String(),
                        LocationTo_City = c.String(),
                        LocationTo_Street = c.String(),
                        LocationTo_Place = c.String(),
                        ServiceType = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        DriverExperience = c.Int(nullable: false),
                        ChosenBidId = c.Long(),
                        CarType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarType_Id)
                .ForeignKey("dbo.Bids", t => t.ChosenBidId)
                .Index(t => t.ChosenBidId)
                .Index(t => t.CarType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ChosenBidId", "dbo.Bids");
            DropForeignKey("dbo.Orders", "CarType_Id", "dbo.Cars");
            DropForeignKey("dbo.Bids", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Bids", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes");
            DropForeignKey("dbo.Cars", "BrandTypeId", "dbo.BrandTypes");
            DropIndex("dbo.Orders", new[] { "CarType_Id" });
            DropIndex("dbo.Orders", new[] { "ChosenBidId" });
            DropIndex("dbo.Cars", new[] { "CarTypeId" });
            DropIndex("dbo.Cars", new[] { "BrandTypeId" });
            DropIndex("dbo.Drivers", new[] { "CarId" });
            DropIndex("dbo.Bids", new[] { "Order_Id" });
            DropIndex("dbo.Bids", new[] { "DriverId" });
            DropTable("dbo.Orders");
            DropTable("dbo.CarTypes");
            DropTable("dbo.BrandTypes");
            DropTable("dbo.Cars");
            DropTable("dbo.Drivers");
            DropTable("dbo.Bids");
        }
    }
}
