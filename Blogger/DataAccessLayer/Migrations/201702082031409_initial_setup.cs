namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Date = c.DateTime(nullable: false),
                        Topic = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Date = c.DateTime(nullable: false),
                        Body = c.String(),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.Blog_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "Blog_Id", "dbo.Blogs");
            DropIndex("dbo.Likes", new[] { "Blog_Id" });
            DropIndex("dbo.Comments", new[] { "Blog_Id" });
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
        }
    }
}
