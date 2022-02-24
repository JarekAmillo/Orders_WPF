namespace Orders_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetTaskNumberRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Claims", "TaskNumber", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Claims", "TaskNumber", c => c.String());
        }
    }
}
