namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportFieldsMedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "LicenseFileName", c => c.String());
            AddColumn("dbo.Reports", "OrganizationpermitFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "OrganizationpermitFileName");
            DropColumn("dbo.Reports", "LicenseFileName");
        }
    }
}
