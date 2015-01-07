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
                        State = c.Int(nullable: false),
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
                        CarType = c.Int(nullable: false),
                        ProductionYear = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.BrandTypeId)
                .Index(t => t.BrandTypeId);
            
            CreateTable(
                "dbo.CarBrands",
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
                        LocationFrom_City = c.String(),
                        LocationFrom_Street = c.String(),
                        LocationFrom_Place = c.String(),
                        LocationTo_City = c.String(),
                        LocationTo_Street = c.String(),
                        LocationTo_Place = c.String(),
                        SuggestedPrice = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        PassangersCount = c.Int(),
                        Description = c.String(),
                        PhoneNumber = c.String(),
                        ConsumerId = c.Int(),
                        Gender = c.Int(nullable: false),
                        DriverExperience = c.Int(),
                        MinimalCarProductionYear = c.Int(),
                        ServiceType = c.Int(nullable: false),
                        ChosenBidId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bids", t => t.ChosenBidId)
                .ForeignKey("dbo.Consumers", t => t.ConsumerId)
                .Index(t => t.ConsumerId)
                .Index(t => t.ChosenBidId);
            
            CreateTable(
                "dbo.Consumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ConsumerId", "dbo.Consumers");
            DropForeignKey("dbo.Orders", "ChosenBidId", "dbo.Bids");
            DropForeignKey("dbo.Bids", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Bids", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "BrandTypeId", "dbo.CarBrands");
            DropIndex("dbo.Orders", new[] { "ChosenBidId" });
            DropIndex("dbo.Orders", new[] { "ConsumerId" });
            DropIndex("dbo.Cars", new[] { "BrandTypeId" });
            DropIndex("dbo.Drivers", new[] { "CarId" });
            DropIndex("dbo.Bids", new[] { "Order_Id" });
            DropIndex("dbo.Bids", new[] { "DriverId" });
            DropTable("dbo.Consumers");
            DropTable("dbo.Orders");
            DropTable("dbo.CarBrands");
            DropTable("dbo.Cars");
            DropTable("dbo.Drivers");
            DropTable("dbo.Bids");
        }
    }
}
