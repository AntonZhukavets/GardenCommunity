namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_19 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Areas", name: "AdditionalAreaId", newName: "ParentAreaId");
            RenameIndex(table: "dbo.Areas", name: "IX_AdditionalAreaId", newName: "IX_ParentAreaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Areas", name: "IX_ParentAreaId", newName: "IX_AdditionalAreaId");
            RenameColumn(table: "dbo.Areas", name: "ParentAreaId", newName: "AdditionalAreaId");
        }
    }
}
