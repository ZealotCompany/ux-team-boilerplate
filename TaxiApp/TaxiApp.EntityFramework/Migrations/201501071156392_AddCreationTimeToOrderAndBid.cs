namespace TaxiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationTimeToOrderAndBid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CreationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CreationTime");
            DropColumn("dbo.Bids", "CreationTime");
        }
    }
}
