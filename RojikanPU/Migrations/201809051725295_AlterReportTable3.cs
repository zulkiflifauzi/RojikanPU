namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterReportTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Origin", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Origin");
        }
    }
}
