namespace Orders_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claims", "TypeOfTask_Id", "dbo.TypeOfTasks");
            DropIndex("dbo.Claims", new[] { "TypeOfTask_Id" });
            RenameColumn(table: "dbo.Claims", name: "TypeOfTask_Id", newName: "TypeOfTaskId");
            AlterColumn("dbo.Claims", "TypeOfTaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.Claims", "TypeOfTaskId");
            AddForeignKey("dbo.Claims", "TypeOfTaskId", "dbo.TypeOfTasks", "Id", cascadeDelete: true);
            DropColumn("dbo.Claims", "TaskId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claims", "TaskId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Claims", "TypeOfTaskId", "dbo.TypeOfTasks");
            DropIndex("dbo.Claims", new[] { "TypeOfTaskId" });
            AlterColumn("dbo.Claims", "TypeOfTaskId", c => c.Int());
            RenameColumn(table: "dbo.Claims", name: "TypeOfTaskId", newName: "TypeOfTask_Id");
            CreateIndex("dbo.Claims", "TypeOfTask_Id");
            AddForeignKey("dbo.Claims", "TypeOfTask_Id", "dbo.TypeOfTasks", "Id");
        }
    }
}
