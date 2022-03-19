namespace Orders_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "DateToRegisterTheClaim", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Claims", "DateToRegisterTheClaim");
        }
    }
}
