namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterArticleFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleFiles", "FileName", c => c.String(nullable: false));
            DropColumn("dbo.ArticleFiles", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArticleFiles", "Content", c => c.Binary(nullable: false));
            DropColumn("dbo.ArticleFiles", "FileName");
        }
    }
}
