namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Areas", "MemberId", "dbo.Members");
            DropIndex("dbo.Areas", new[] { "MemberId" });
            AlterColumn("dbo.Areas", "MemberId", c => c.Int());
            CreateIndex("dbo.Areas", "MemberId");
            AddForeignKey("dbo.Areas", "MemberId", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "MemberId", "dbo.Members");
            DropIndex("dbo.Areas", new[] { "MemberId" });
            AlterColumn("dbo.Areas", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Areas", "MemberId");
            AddForeignKey("dbo.Areas", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
