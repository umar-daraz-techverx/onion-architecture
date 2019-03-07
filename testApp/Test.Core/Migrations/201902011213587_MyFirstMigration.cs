namespace Test.Core.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseEntity",
                c => new
                    {
                        rec_id = c.Guid(nullable: false),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.rec_id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        rec_id = c.Guid(nullable: false),
                        Blog_rec_id = c.Guid(),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.rec_id)
                .ForeignKey("dbo.Blog", t => t.Blog_rec_id)
                .Index(t => t.Blog_rec_id);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        rec_id = c.Guid(nullable: false),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.rec_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Blog_rec_id", "dbo.Blog");
            DropIndex("dbo.Post", new[] { "Blog_rec_id" });
            DropTable("dbo.Blog");
            DropTable("dbo.Post");
            DropTable("dbo.BaseEntity");
        }
    }
}
