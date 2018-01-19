namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAppser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUsers", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AppUsers", new[] { "EmployeeId" });
            AddColumn("dbo.AppUsers", "ConfirmPassword", c => c.String());
            DropColumn("dbo.AppUsers", "EmployeeId");
            DropColumn("dbo.AppUsers", "IsEmailVerified");
            DropColumn("dbo.AppUsers", "ActivationCode");
            DropColumn("dbo.AppUsers", "Notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "Notes", c => c.String());
            AddColumn("dbo.AppUsers", "ActivationCode", c => c.Guid(nullable: false));
            AddColumn("dbo.AppUsers", "IsEmailVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppUsers", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.AppUsers", "ConfirmPassword");
            CreateIndex("dbo.AppUsers", "EmployeeId");
            AddForeignKey("dbo.AppUsers", "EmployeeId", "dbo.Employees", "Id");
        }
    }
}
