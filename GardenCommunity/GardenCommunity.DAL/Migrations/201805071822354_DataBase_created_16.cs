namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indications", "LoosesPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Indications", "LoosesPercent");
        }
    }
}
