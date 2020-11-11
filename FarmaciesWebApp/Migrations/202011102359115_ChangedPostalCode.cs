namespace FarmaciesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPostalCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Farmacies", "PostalCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Farmacies", "PostalCode", c => c.Short(nullable: false));
        }
    }
}
