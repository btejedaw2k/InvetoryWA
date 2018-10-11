namespace InventoryWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriesTableWithValidation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        Nombre = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true, name: "CodigoCategoriaIndex")
                .Index(t => t.Nombre, unique: true, name: "NombreCategoriaIndex");
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Categie_Id = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, unicode: false),
                        Detalle = c.String(unicode: false),
                        Codigo = c.String(nullable: false, maxLength: 35, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.Id, t.Categie_Id })
                .ForeignKey("dbo.Categories", t => t.Categie_Id, cascadeDelete: true)
                .Index(t => t.Categie_Id)
                .Index(t => t.Codigo, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Categie_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Codigo" });
            DropIndex("dbo.Products", new[] { "Categie_Id" });
            DropIndex("dbo.Categories", "NombreCategoriaIndex");
            DropIndex("dbo.Categories", "CodigoCategoriaIndex");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
