namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Email", c => c.String());
        }
    }
}
