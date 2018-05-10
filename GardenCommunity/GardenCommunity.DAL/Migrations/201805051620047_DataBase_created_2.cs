namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Rate_Id", "dbo.Rates");
            DropIndex("dbo.Payments", new[] { "Rate_Id" });
            RenameColumn(table: "dbo.Payments", name: "Rate_Id", newName: "RateId");
            AddColumn("dbo.Payments", "IndicationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "RateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "RateId");
            AddForeignKey("dbo.Payments", "RateId", "dbo.Rates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "RateId", "dbo.Rates");
            DropIndex("dbo.Payments", new[] { "RateId" });
            AlterColumn("dbo.Payments", "RateId", c => c.Int());
            DropColumn("dbo.Payments", "IndicationId");
            RenameColumn(table: "dbo.Payments", name: "RateId", newName: "Rate_Id");
            CreateIndex("dbo.Payments", "Rate_Id");
            AddForeignKey("dbo.Payments", "Rate_Id", "dbo.Rates", "Id");
        }
    }
}
