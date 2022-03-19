namespace Orders_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimNumber = c.String(),
                        TaskNumber = c.String(),
                        TaskId = c.Int(nullable: false),
                        TypeOfTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfTasks", t => t.TypeOfTask_Id)
                .Index(t => t.TypeOfTask_Id);
            
            CreateTable(
                "dbo.TypeOfTasks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Claims", "TypeOfTask_Id", "dbo.TypeOfTasks");
            DropIndex("dbo.Claims", new[] { "TypeOfTask_Id" });
            DropTable("dbo.TypeOfTasks");
            DropTable("dbo.Claims");
        }
    }
}
