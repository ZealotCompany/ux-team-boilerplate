namespace TaxiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesReplaced : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "CarType_Id", newName: "CarDetails_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_CarType_Id", newName: "IX_CarDetails_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_CarDetails_Id", newName: "IX_CarType_Id");
            RenameColumn(table: "dbo.Orders", name: "CarDetails_Id", newName: "CarType_Id");
        }
    }
}
