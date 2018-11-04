namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSomeFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IDCardFiles", "ReportId", "dbo.Reports");
            DropIndex("dbo.IDCardFiles", new[] { "ReportId" });
            AddColumn("dbo.Reports", "IDCardFileName", c => c.String());
            DropTable("dbo.IDCardFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IDCardFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Reports", "IDCardFileName");
            CreateIndex("dbo.IDCardFiles", "ReportId");
            AddForeignKey("dbo.IDCardFiles", "ReportId", "dbo.Reports", "Id", cascadeDelete: true);
        }
    }
}
