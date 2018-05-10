namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MembersAreas", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MembersAreas", "AreaId", "dbo.Areas");
            DropIndex("dbo.MembersAreas", new[] { "MemberId" });
            DropIndex("dbo.MembersAreas", new[] { "AreaId" });
            AddColumn("dbo.Areas", "Member_Id", c => c.Int());
            AddColumn("dbo.Members", "MiddleName", c => c.String());
            CreateIndex("dbo.Areas", "Member_Id");
            AddForeignKey("dbo.Areas", "Member_Id", "dbo.Members", "Id");
            DropColumn("dbo.Members", "Petronymic");
            DropTable("dbo.MembersAreas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MembersAreas",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.AreaId });
            
            AddColumn("dbo.Members", "Petronymic", c => c.String());
            DropForeignKey("dbo.Areas", "Member_Id", "dbo.Members");
            DropIndex("dbo.Areas", new[] { "Member_Id" });
            DropColumn("dbo.Members", "MiddleName");
            DropColumn("dbo.Areas", "Member_Id");
            CreateIndex("dbo.MembersAreas", "AreaId");
            CreateIndex("dbo.MembersAreas", "MemberId");
            AddForeignKey("dbo.MembersAreas", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MembersAreas", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
