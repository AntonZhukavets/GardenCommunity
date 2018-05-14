namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DataBase_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Square = c.Int(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        HasElectricity = c.Boolean(nullable: false),
                        ParentAreaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.ParentAreaId)
                .Index(t => t.ParentAreaId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false, maxLength: 20),
                        AdditionalInfo = c.String(),
                        IsActiveMember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfPayment = c.DateTime(nullable: false),
                        PaidFor = c.Double(nullable: false),
                        ToPay = c.Double(nullable: false),
                        RateId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Rates", t => t.RateId, cascadeDelete: true)
                .Index(t => t.RateId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Indication",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        LastIndication = c.Double(nullable: false),
                        CurrentIndication = c.Double(nullable: false),
                        LoosesPercent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateName = c.String(nullable: false, maxLength: 50),
                        RateValue = c.Double(nullable: false),
                        BankCollectionPercent = c.Double(nullable: false),
                        FinePercent = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembersAreas",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.AreaId })
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Area", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Area", "ParentAreaId", "dbo.Area");
            DropForeignKey("dbo.Payment", "RateId", "dbo.Rates");
            DropForeignKey("dbo.Payment", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Indication", "Id", "dbo.Payment");
            DropForeignKey("dbo.MembersAreas", "AreaId", "dbo.Area");
            DropForeignKey("dbo.MembersAreas", "MemberId", "dbo.Member");
            DropIndex("dbo.MembersAreas", new[] { "AreaId" });
            DropIndex("dbo.MembersAreas", new[] { "MemberId" });
            DropIndex("dbo.Indication", new[] { "Id" });
            DropIndex("dbo.Payment", new[] { "MemberId" });
            DropIndex("dbo.Payment", new[] { "RateId" });
            DropIndex("dbo.Area", new[] { "ParentAreaId" });
            DropTable("dbo.MembersAreas");
            DropTable("dbo.Rates");
            DropTable("dbo.Indication");
            DropTable("dbo.Payment");
            DropTable("dbo.Member");
            DropTable("dbo.Area");
        }
    }
}
