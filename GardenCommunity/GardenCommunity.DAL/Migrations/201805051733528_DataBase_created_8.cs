namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indications", "PaymentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Indications", "PaymentId");
        }
    }
}
