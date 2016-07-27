namespace ManoVerslas.Migrations.PageDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Page : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildCategory",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 128),
                        ParentCategoryId = c.String(nullable: false, maxLength: 128),
                        CCatName = c.String(nullable: false),
                        NumberOfPages = c.Int(nullable: false),
                        UrlSeo = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageId, t.ParentCategoryId })
                .ForeignKey("dbo.Page", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        Meta = c.String(nullable: false),
                        UrlSeo = c.String(nullable: false),
                        UserImage = c.String(nullable: false),
                        Exp = c.Int(nullable: false),
                        Logo = c.String(),
                        WebURL = c.String(),
                        FacebookUrl = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        PageId = c.String(maxLength: 128),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.PageId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.PageStar",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 128),
                        StarNumberPlus = c.Boolean(nullable: false),
                        StarNumberMinus = c.Boolean(nullable: false),
                        Page_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.Page", t => t.Page_Id)
                .Index(t => t.Page_Id);
            
            CreateTable(
                "dbo.ParentCategory",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PCatName = c.String(nullable: false),
                        NumberOfPages = c.Int(nullable: false),
                        UrlSeo = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Page_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.Page_Id)
                .Index(t => t.Page_Id);
            
            CreateTable(
                "dbo.ParentCategoryChildCategory",
                c => new
                    {
                        ParentCategory_Id = c.String(nullable: false, maxLength: 128),
                        ChildCategory_PageId = c.String(nullable: false, maxLength: 128),
                        ChildCategory_ParentCategoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ParentCategory_Id, t.ChildCategory_PageId, t.ChildCategory_ParentCategoryId })
                .ForeignKey("dbo.ParentCategory", t => t.ParentCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.ChildCategory", t => new { t.ChildCategory_PageId, t.ChildCategory_ParentCategoryId }, cascadeDelete: true)
                .Index(t => t.ParentCategory_Id)
                .Index(t => new { t.ChildCategory_PageId, t.ChildCategory_ParentCategoryId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParentCategory", "Page_Id", "dbo.Page");
            DropForeignKey("dbo.ParentCategoryChildCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" }, "dbo.ChildCategory");
            DropForeignKey("dbo.ParentCategoryChildCategory", "ParentCategory_Id", "dbo.ParentCategory");
            DropForeignKey("dbo.PageStar", "Page_Id", "dbo.Page");
            DropForeignKey("dbo.PageImage", "PageId", "dbo.Page");
            DropForeignKey("dbo.ChildCategory", "PageId", "dbo.Page");
            DropIndex("dbo.ParentCategoryChildCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" });
            DropIndex("dbo.ParentCategoryChildCategory", new[] { "ParentCategory_Id" });
            DropIndex("dbo.ParentCategory", new[] { "Page_Id" });
            DropIndex("dbo.PageStar", new[] { "Page_Id" });
            DropIndex("dbo.PageImage", new[] { "PageId" });
            DropIndex("dbo.ChildCategory", new[] { "PageId" });
            DropTable("dbo.ParentCategoryChildCategory");
            DropTable("dbo.ParentCategory");
            DropTable("dbo.PageStar");
            DropTable("dbo.PageImage");
            DropTable("dbo.Page");
            DropTable("dbo.ChildCategory");
        }
    }
}
