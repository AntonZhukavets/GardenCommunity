namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Areas", "MemberId", "dbo.Members");
            DropIndex("dbo.Areas", new[] { "MemberId" });
            CreateTable(
                "dbo.MembersAreas",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.AreaId })
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.AreaId);
            
            DropColumn("dbo.Areas", "MemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Areas", "MemberId", c => c.Int());
            DropForeignKey("dbo.MembersAreas", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.MembersAreas", "MemberId", "dbo.Members");
            DropIndex("dbo.MembersAreas", new[] { "AreaId" });
            DropIndex("dbo.MembersAreas", new[] { "MemberId" });
            DropTable("dbo.MembersAreas");
            CreateIndex("dbo.Areas", "MemberId");
            AddForeignKey("dbo.Areas", "MemberId", "dbo.Members", "Id");
        }
    }
}
