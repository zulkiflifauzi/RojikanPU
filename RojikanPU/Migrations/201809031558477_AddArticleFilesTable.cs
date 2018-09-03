namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleFilesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleFiles", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleFiles", new[] { "ArticleId" });
            DropTable("dbo.ArticleFiles");
        }
    }
}
