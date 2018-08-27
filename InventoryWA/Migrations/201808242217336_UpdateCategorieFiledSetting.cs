namespace InventoryWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategorieFiledSetting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Codigo", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
            CreateIndex("dbo.Products", "Codigo", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Codigo" });
            AlterColumn("dbo.Products", "Codigo", c => c.String(unicode: false));
        }
    }
}
