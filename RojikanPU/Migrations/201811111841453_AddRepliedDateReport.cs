namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRepliedDateReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "RepliedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "RepliedDate");
        }
    }
}
