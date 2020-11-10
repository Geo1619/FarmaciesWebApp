namespace FarmaciesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLocationsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO LOCATIONS (Name) VALUES ('Κερατσίνι')");
            Sql("INSERT INTO LOCATIONS (Name) VALUES ('Νέος Κόσμος')");
            Sql("INSERT INTO LOCATIONS (Name) VALUES ('Παγκράτι')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM LOCATIONS WHERE Id IN (1, 2, 3)");
        }
    }
}
