namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeEdu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EducationId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        Subject = c.String(nullable: false),
                        InstituteName = c.String(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Duration = c.String(nullable: false, maxLength: 25),
                        PassingYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.EmployeeId)
                .Index(t => t.EducationId)
                .Index(t => t.ExamId);
            
            DropTable("dbo.EmployeeEducations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.EmployeEducations", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.EmployeEducations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeEducations", "EducationId", "dbo.Educations");
            DropIndex("dbo.EmployeEducations", new[] { "ExamId" });
            DropIndex("dbo.EmployeEducations", new[] { "EducationId" });
            DropIndex("dbo.EmployeEducations", new[] { "EmployeeId" });
            DropTable("dbo.EmployeEducations");
        }
    }
}
