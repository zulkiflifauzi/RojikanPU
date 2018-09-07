namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterReportTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "ProcessDate", c => c.DateTime());
            AlterColumn("dbo.Reports", "ClosedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "ClosedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reports", "ProcessDate", c => c.DateTime(nullable: false));
        }
    }
}
