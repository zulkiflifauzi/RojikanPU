namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PPKFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.ReporterFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.StaffFiles",
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
            DropForeignKey("dbo.StaffFiles", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReporterFiles", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.PPKFiles", "ReportId", "dbo.Reports");
            DropIndex("dbo.StaffFiles", new[] { "ReportId" });
            DropIndex("dbo.ReporterFiles", new[] { "ReportId" });
            DropIndex("dbo.PPKFiles", new[] { "ReportId" });
            DropTable("dbo.StaffFiles");
            DropTable("dbo.ReporterFiles");
            DropTable("dbo.PPKFiles");
        }
    }
}
