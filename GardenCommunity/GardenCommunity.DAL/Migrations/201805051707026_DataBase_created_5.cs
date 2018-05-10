namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Payments", name: "Rate_Id", newName: "RateId");
            RenameIndex(table: "dbo.Payments", name: "IX_Rate_Id", newName: "IX_RateId");
            AddColumn("dbo.Rates", "RateValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rates", "RateValue");
            RenameIndex(table: "dbo.Payments", name: "IX_RateId", newName: "IX_Rate_Id");
            RenameColumn(table: "dbo.Payments", name: "RateId", newName: "Rate_Id");
        }
    }
}
