namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Areas", "MemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Areas", "MemberId", c => c.Int(nullable: false));
        }
    }
}
