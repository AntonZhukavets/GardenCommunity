namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Payments", "IndicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "IndicationId", c => c.Int(nullable: false));
        }
    }
}
