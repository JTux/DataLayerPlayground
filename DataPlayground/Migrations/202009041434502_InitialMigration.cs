namespace DataPlayground.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LiquorUses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CocktailId = c.Int(nullable: false),
                        LiquorId = c.Int(),
                        SpecificId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LiquorEntities", t => t.LiquorId, cascadeDelete: true)
                .ForeignKey("dbo.SpecificLiquorEntities", t => t.SpecificId, cascadeDelete: false)
                .ForeignKey("dbo.CocktailEntities", t => t.CocktailId, cascadeDelete: false)
                .Index(t => t.CocktailId)
                .Index(t => t.LiquorId)
                .Index(t => t.SpecificId);
            
            CreateTable(
                "dbo.CocktailEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LiquorEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        SubType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecificLiquorEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LiquorId = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        CountryOfOrigin = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LiquorEntities", t => t.LiquorId, cascadeDelete: true)
                .Index(t => t.LiquorId);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PasswordInPlainText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LiquorUses", "CocktailId", "dbo.CocktailEntities");
            DropForeignKey("dbo.LiquorUses", "SpecificId", "dbo.SpecificLiquorEntities");
            DropForeignKey("dbo.SpecificLiquorEntities", "LiquorId", "dbo.LiquorEntities");
            DropForeignKey("dbo.LiquorUses", "LiquorId", "dbo.LiquorEntities");
            DropIndex("dbo.SpecificLiquorEntities", new[] { "LiquorId" });
            DropIndex("dbo.LiquorUses", new[] { "SpecificId" });
            DropIndex("dbo.LiquorUses", new[] { "LiquorId" });
            DropIndex("dbo.LiquorUses", new[] { "CocktailId" });
            DropTable("dbo.UserEntities");
            DropTable("dbo.SpecificLiquorEntities");
            DropTable("dbo.LiquorEntities");
            DropTable("dbo.CocktailEntities");
            DropTable("dbo.LiquorUses");
        }
    }
}
