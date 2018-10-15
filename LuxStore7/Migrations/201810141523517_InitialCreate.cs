namespace LuxStore7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        logo = c.String(),
                        CompanyTypeId = c.Int(nullable: false),
                        Cost = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyTypes", t => t.CompanyTypeId, cascadeDelete: true)
                .Index(t => t.CompanyTypeId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CompanyTypeId", "dbo.CompanyTypes");
            DropForeignKey("dbo.Comments", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Comments", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CompanyTypeId" });
            DropTable("dbo.CompanyTypes");
            DropTable("dbo.Comments");
            DropTable("dbo.Companies");
        }
    }
}
