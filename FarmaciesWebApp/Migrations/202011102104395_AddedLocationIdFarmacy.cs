namespace FarmaciesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationIdFarmacy : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Farmacies", name: "Location_Id", newName: "LocationId");
            RenameIndex(table: "dbo.Farmacies", name: "IX_Location_Id", newName: "IX_LocationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Farmacies", name: "IX_LocationId", newName: "IX_Location_Id");
            RenameColumn(table: "dbo.Farmacies", name: "LocationId", newName: "Location_Id");
        }
    }
}
