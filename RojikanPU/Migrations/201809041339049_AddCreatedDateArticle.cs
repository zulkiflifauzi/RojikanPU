namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "CreatedDate");
        }
    }
}
