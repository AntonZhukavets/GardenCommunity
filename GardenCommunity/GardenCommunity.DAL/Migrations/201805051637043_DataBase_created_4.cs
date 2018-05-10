namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Payments", name: "RateId", newName: "Rate_Id");
            RenameIndex(table: "dbo.Payments", name: "IX_RateId", newName: "IX_Rate_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Payments", name: "IX_Rate_Id", newName: "IX_RateId");
            RenameColumn(table: "dbo.Payments", name: "Rate_Id", newName: "RateId");
        }
    }
}
