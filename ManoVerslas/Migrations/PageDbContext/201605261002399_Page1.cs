namespace ManoVerslas.Migrations.PageDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Page1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParentCategoryChildCategory", "ParentCategory_Id", "dbo.ParentCategory");
            DropForeignKey("dbo.ParentCategoryChildCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" }, "dbo.ChildCategory");
            DropIndex("dbo.ParentCategoryChildCategory", new[] { "ParentCategory_Id" });
            DropIndex("dbo.ParentCategoryChildCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" });
            AddColumn("dbo.ChildCategory", "ParentCategory_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.ParentCategory", "ChildCategory_PageId", c => c.String(maxLength: 128));
            AddColumn("dbo.ParentCategory", "ChildCategory_ParentCategoryId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChildCategory", "ParentCategoryId");
            CreateIndex("dbo.ChildCategory", "ParentCategory_Id");
            CreateIndex("dbo.ParentCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" });
            AddForeignKey("dbo.ChildCategory", "ParentCategory_Id", "dbo.ParentCategory", "Id");
            AddForeignKey("dbo.ParentCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" }, "dbo.ChildCategory", new[] { "PageId", "ParentCategoryId" });
            AddForeignKey("dbo.ChildCategory", "ParentCategoryId", "dbo.ParentCategory", "Id", cascadeDelete: true);
            DropTable("dbo.ParentCategoryChildCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParentCategoryChildCategory",
                c => new
                    {
                        ParentCategory_Id = c.String(nullable: false, maxLength: 128),
                        ChildCategory_PageId = c.String(nullable: false, maxLength: 128),
                        ChildCategory_ParentCategoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ParentCategory_Id, t.ChildCategory_PageId, t.ChildCategory_ParentCategoryId });
            
            DropForeignKey("dbo.ChildCategory", "ParentCategoryId", "dbo.ParentCategory");
            DropForeignKey("dbo.ParentCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" }, "dbo.ChildCategory");
            DropForeignKey("dbo.ChildCategory", "ParentCategory_Id", "dbo.ParentCategory");
            DropIndex("dbo.ParentCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" });
            DropIndex("dbo.ChildCategory", new[] { "ParentCategory_Id" });
            DropIndex("dbo.ChildCategory", new[] { "ParentCategoryId" });
            DropColumn("dbo.ParentCategory", "ChildCategory_ParentCategoryId");
            DropColumn("dbo.ParentCategory", "ChildCategory_PageId");
            DropColumn("dbo.ChildCategory", "ParentCategory_Id");
            CreateIndex("dbo.ParentCategoryChildCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" });
            CreateIndex("dbo.ParentCategoryChildCategory", "ParentCategory_Id");
            AddForeignKey("dbo.ParentCategoryChildCategory", new[] { "ChildCategory_PageId", "ChildCategory_ParentCategoryId" }, "dbo.ChildCategory", new[] { "PageId", "ParentCategoryId" }, cascadeDelete: true);
            AddForeignKey("dbo.ParentCategoryChildCategory", "ParentCategory_Id", "dbo.ParentCategory", "Id", cascadeDelete: true);
        }
    }
}
