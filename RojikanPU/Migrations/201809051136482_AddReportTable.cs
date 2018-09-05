namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PPKId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PPKs", t => t.PPKId)
                .Index(t => t.PPKId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "PPKId", "dbo.PPKs");
            DropIndex("dbo.Reports", new[] { "PPKId" });
            DropTable("dbo.Reports");
        }
    }
}
