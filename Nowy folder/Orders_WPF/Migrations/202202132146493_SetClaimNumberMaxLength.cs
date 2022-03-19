namespace Orders_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetClaimNumberMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Claims", "ClaimNumber", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.TypeOfTasks", "Name", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeOfTasks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Claims", "ClaimNumber", c => c.String());
        }
    }
}
