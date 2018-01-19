namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAppUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "EmployeeId" });
            DropIndex("dbo.Admins", new[] { "UserName" });
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropIndex("dbo.Roles", new[] { "RoleName" });
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 100),
                        EmailAddress = c.String(nullable: false, maxLength: 255),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.EmployeeId)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.EmailAddress, unique: true)
                .Index(t => t.RoleId);
            
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Roles", "Description", c => c.String(maxLength: 50));
            CreateIndex("dbo.Roles", "RoleName", unique: true);
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        RoleId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AppUsers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.AppUsers", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Roles", new[] { "RoleName" });
            DropIndex("dbo.AppUsers", new[] { "RoleId" });
            DropIndex("dbo.AppUsers", new[] { "EmailAddress" });
            DropIndex("dbo.AppUsers", new[] { "UserName" });
            DropIndex("dbo.AppUsers", new[] { "EmployeeId" });
            AlterColumn("dbo.Roles", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.AppUsers");
            CreateIndex("dbo.Roles", "RoleName", unique: true);
            CreateIndex("dbo.Admins", "RoleId");
            CreateIndex("dbo.Admins", "UserName", unique: true);
            CreateIndex("dbo.Admins", "EmployeeId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.Admins", "EmployeeId", "dbo.Employees", "Id");
        }
    }
}
