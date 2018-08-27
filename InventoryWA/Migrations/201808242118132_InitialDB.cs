namespace InventoryWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Categie_Id = c.Int(nullable: false),
                        Codigo = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        Detalle = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Categie_Id })
                .ForeignKey("dbo.Categories", t => t.Categie_Id, cascadeDelete: true)
                .Index(t => t.Categie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Categie_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categie_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
