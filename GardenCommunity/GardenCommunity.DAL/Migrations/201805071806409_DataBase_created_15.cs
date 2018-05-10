namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Areas", "Member_Id", "dbo.Members");
            DropIndex("dbo.Areas", new[] { "Member_Id" });
            RenameColumn(table: "dbo.Areas", name: "Member_Id", newName: "MemberId");
            AlterColumn("dbo.Areas", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Areas", "MemberId");
            AddForeignKey("dbo.Areas", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "MemberId", "dbo.Members");
            DropIndex("dbo.Areas", new[] { "MemberId" });
            AlterColumn("dbo.Areas", "MemberId", c => c.Int());
            RenameColumn(table: "dbo.Areas", name: "MemberId", newName: "Member_Id");
            CreateIndex("dbo.Areas", "Member_Id");
            AddForeignKey("dbo.Areas", "Member_Id", "dbo.Members", "Id");
        }
    }
}
