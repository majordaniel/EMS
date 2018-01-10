namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmploymentHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmploymentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        CompanyLocation = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        EmploymentFromDate = c.DateTime(nullable: false),
                        IsCurrentEmployee = c.Int(nullable: false),
                        EmploymentToDate = c.DateTime(nullable: false),
                        Responsibilities = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmploymentHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmploymentHistories", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.EmploymentHistories", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.EmploymentHistories", new[] { "DesignationId" });
            DropIndex("dbo.EmploymentHistories", new[] { "DepartmentId" });
            DropIndex("dbo.EmploymentHistories", new[] { "EmployeeId" });
            DropTable("dbo.EmploymentHistories");
        }
    }
}
