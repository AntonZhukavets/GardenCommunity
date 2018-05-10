namespace GardenCommunity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_created_13 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Areas", name: "AdditionalArea_Id", newName: "AdditionalAreaId");
            RenameIndex(table: "dbo.Areas", name: "IX_AdditionalArea_Id", newName: "IX_AdditionalAreaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Areas", name: "IX_AdditionalAreaId", newName: "IX_AdditionalArea_Id");
            RenameColumn(table: "dbo.Areas", name: "AdditionalAreaId", newName: "AdditionalArea_Id");
        }
    }
}
