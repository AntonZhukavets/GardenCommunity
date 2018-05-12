namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBasecreated_17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "IndicationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "IndicationId");
        }
    }
}
