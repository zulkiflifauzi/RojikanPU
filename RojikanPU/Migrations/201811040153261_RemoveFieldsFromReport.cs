namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFieldsFromReport : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reports", "IDCardURL");
            DropColumn("dbo.Reports", "LicenseURL");
            DropColumn("dbo.Reports", "OrganizationPermitURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "OrganizationPermitURL", c => c.String());
            AddColumn("dbo.Reports", "LicenseURL", c => c.String());
            AddColumn("dbo.Reports", "IDCardURL", c => c.String());
        }
    }
}
