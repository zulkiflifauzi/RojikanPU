namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterReportTable5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Email");
        }
    }
}
