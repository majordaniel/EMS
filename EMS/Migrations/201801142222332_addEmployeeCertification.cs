namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeCertification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeCertifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CertificationId = c.Int(nullable: false),
                        InstituteName = c.String(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeCertifications");
        }
    }
}
