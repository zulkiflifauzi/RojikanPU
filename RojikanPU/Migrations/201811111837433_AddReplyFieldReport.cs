namespace RojikanPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReplyFieldReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Reply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Reply");
        }
    }
}
