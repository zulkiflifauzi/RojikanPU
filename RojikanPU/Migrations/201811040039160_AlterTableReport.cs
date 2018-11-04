namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "IDCard", c => c.Binary());
            AddColumn("dbo.Reports", "License", c => c.Binary());
            AddColumn("dbo.Reports", "OrganizationPermit", c => c.Binary());
            AddColumn("dbo.Reports", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Type");
            DropColumn("dbo.Reports", "OrganizationPermit");
            DropColumn("dbo.Reports", "License");
            DropColumn("dbo.Reports", "IDCard");
        }
    }
}
