namespace LuxStore7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "MealCategory_Id", c => c.Int());
            CreateIndex("dbo.Products", "MealCategory_Id");
            AddForeignKey("dbo.Products", "MealCategory_Id", "dbo.MealCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "MealCategory_Id", "dbo.MealCategories");
            DropIndex("dbo.Products", new[] { "MealCategory_Id" });
            DropColumn("dbo.Products", "MealCategory_Id");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.MealCategories");
        }
    }
}
