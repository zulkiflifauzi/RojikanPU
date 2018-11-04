namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDCardFileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IDCardFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IDCardFiles", "ReportId", "dbo.Reports");
            DropIndex("dbo.IDCardFiles", new[] { "ReportId" });
            DropTable("dbo.IDCardFiles");
        }
    }
}
