namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterReportTable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Status");
        }
    }
}
