namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPPKTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PPKs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PPKs", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.PPKs", new[] { "Id" });
            DropTable("dbo.PPKs");
        }
    }
}
