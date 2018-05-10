namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "MemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Areas", "MemberId");
        }
    }
}
