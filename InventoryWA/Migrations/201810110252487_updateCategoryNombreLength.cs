namespace InventoryWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategoryNombreLength : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", "NombreCategoriaIndex");
            AlterColumn("dbo.Categories", "Nombre", c => c.String(nullable: false, maxLength: 35, storeType: "nvarchar"));
            CreateIndex("dbo.Categories", "Nombre", unique: true, name: "NombreCategoriaIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", "NombreCategoriaIndex");
            AlterColumn("dbo.Categories", "Nombre", c => c.String(nullable: false, maxLength: 15, storeType: "nvarchar"));
            CreateIndex("dbo.Categories", "Nombre", unique: true, name: "NombreCategoriaIndex");
        }
    }
}
