namespace LuxStore7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "MealCategory_Id", "dbo.MealCategories");
            DropIndex("dbo.Products", new[] { "MealCategory_Id" });
            RenameColumn(table: "dbo.Products", name: "MealCategory_Id", newName: "MealCategoryId");
            AddColumn("dbo.Products", "ProductCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "MealCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductCategoryId");
            CreateIndex("dbo.Products", "MealCategoryId");
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "MealCategoryId", "dbo.MealCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "MealCategoryId", "dbo.MealCategories");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "MealCategoryId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            AlterColumn("dbo.Products", "MealCategoryId", c => c.Int());
            DropColumn("dbo.Products", "ProductCategoryId");
            RenameColumn(table: "dbo.Products", name: "MealCategoryId", newName: "MealCategory_Id");
            CreateIndex("dbo.Products", "MealCategory_Id");
            AddForeignKey("dbo.Products", "MealCategory_Id", "dbo.MealCategories", "Id");
        }
    }
}
