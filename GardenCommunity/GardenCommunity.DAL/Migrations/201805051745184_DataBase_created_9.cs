namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Indications", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Indications", "PaymentId", c => c.Int(nullable: false));
        }
    }
}
