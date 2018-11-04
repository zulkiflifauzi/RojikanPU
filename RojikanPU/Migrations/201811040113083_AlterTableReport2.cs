namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableReport2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "IDCardURL", c => c.String());
            AddColumn("dbo.Reports", "LicenseURL", c => c.String());
            AddColumn("dbo.Reports", "OrganizationPermitURL", c => c.String());
            DropColumn("dbo.Reports", "IDCard");
            DropColumn("dbo.Reports", "License");
            DropColumn("dbo.Reports", "OrganizationPermit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "OrganizationPermit", c => c.Binary());
            AddColumn("dbo.Reports", "License", c => c.Binary());
            AddColumn("dbo.Reports", "IDCard", c => c.Binary());
            DropColumn("dbo.Reports", "OrganizationPermitURL");
            DropColumn("dbo.Reports", "LicenseURL");
            DropColumn("dbo.Reports", "IDCardURL");
        }
    }
}
