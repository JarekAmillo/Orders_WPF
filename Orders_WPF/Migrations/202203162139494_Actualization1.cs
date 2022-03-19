namespace Orders_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualization1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Claims", "Comments");
        }
    }
}
