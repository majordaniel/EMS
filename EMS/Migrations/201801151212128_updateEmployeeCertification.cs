namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeCertification : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EmployeeCertifications", "EmployeeId");
            CreateIndex("dbo.EmployeeCertifications", "CertificationId");
            AddForeignKey("dbo.EmployeeCertifications", "CertificationId", "dbo.Certifications", "Id");
            AddForeignKey("dbo.EmployeeCertifications", "EmployeeId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeCertifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCertifications", "CertificationId", "dbo.Certifications");
            DropIndex("dbo.EmployeeCertifications", new[] { "CertificationId" });
            DropIndex("dbo.EmployeeCertifications", new[] { "EmployeeId" });
        }
    }
}
