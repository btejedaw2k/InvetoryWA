namespace InventoryWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableMiselaneos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Miscelaneos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        Descripcion = c.String(nullable: false, maxLength: 35, storeType: "nvarchar"),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "CodigoMiscelaneoIndex")
                .Index(t => t.Descripcion, unique: true, name: "NombreMiscelaneIndex");
            
            AddColumn("dbo.Categories", "Miselaneos_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "Miselaneos_Id");
            AddForeignKey("dbo.Categories", "Miselaneos_Id", "dbo.Miscelaneos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Miselaneos_Id", "dbo.Miscelaneos");
            DropIndex("dbo.Miscelaneos", "NombreMiscelaneIndex");
            DropIndex("dbo.Miscelaneos", "CodigoMiscelaneoIndex");
            DropIndex("dbo.Categories", new[] { "Miselaneos_Id" });
            DropColumn("dbo.Categories", "Miselaneos_Id");
            DropTable("dbo.Miscelaneos");
        }
    }
}
