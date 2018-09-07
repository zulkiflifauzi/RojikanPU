namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterReportTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reports", "ProcessDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reports", "ClosedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reports", "StaffComment", c => c.String());
            AddColumn("dbo.Reports", "PPKComment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "PPKComment");
            DropColumn("dbo.Reports", "StaffComment");
            DropColumn("dbo.Reports", "ClosedDate");
            DropColumn("dbo.Reports", "ProcessDate");
            DropColumn("dbo.Reports", "CreatedDate");
        }
    }
}
