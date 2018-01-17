namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeDocuments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DocumentTypeId = c.Int(nullable: false),
                        DocumentTitle = c.String(nullable: false, maxLength: 100),
                        DocumentAddedDate = c.DateTime(nullable: false),
                        ExpiredDate = c.DateTime(nullable: false),
                        Details = c.String(maxLength: 150),
                        FilePath = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.DocumentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDocuments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeDocuments", "DocumentTypeId", "dbo.DocumentTypes");
            DropIndex("dbo.EmployeeDocuments", new[] { "DocumentTypeId" });
            DropIndex("dbo.EmployeeDocuments", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeDocuments");
        }
    }
}
