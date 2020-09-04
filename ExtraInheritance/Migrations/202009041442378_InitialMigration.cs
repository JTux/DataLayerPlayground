namespace ExtraInheritance.Migrations
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
                .ForeignKey("dbo.LiquorEntities", t => t.SpecificId, cascadeDelete: false)
                .ForeignKey("dbo.CocktailEntities", t => t.CocktailId, cascadeDelete: true)
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
                        LiquorId = c.Int(),
                        Brand = c.String(),
                        CountryOfOrigin = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LiquorEntities", t => t.LiquorId)
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
            DropForeignKey("dbo.LiquorUses", "SpecificId", "dbo.LiquorEntities");
            DropForeignKey("dbo.LiquorUses", "LiquorId", "dbo.LiquorEntities");
            DropForeignKey("dbo.LiquorEntities", "LiquorId", "dbo.LiquorEntities");
            DropIndex("dbo.LiquorEntities", new[] { "LiquorId" });
            DropIndex("dbo.LiquorUses", new[] { "SpecificId" });
            DropIndex("dbo.LiquorUses", new[] { "LiquorId" });
            DropIndex("dbo.LiquorUses", new[] { "CocktailId" });
            DropTable("dbo.UserEntities");
            DropTable("dbo.LiquorEntities");
            DropTable("dbo.CocktailEntities");
            DropTable("dbo.LiquorUses");
        }
    }
}
