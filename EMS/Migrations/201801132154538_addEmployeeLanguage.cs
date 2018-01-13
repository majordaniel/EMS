namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeLanguage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Reading = c.String(nullable: false, maxLength: 50),
                        Speaking = c.String(nullable: false, maxLength: 50),
                        Writing = c.String(nullable: false, maxLength: 50),
                        Understanding = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeLanguages", new[] { "LanguageId" });
            DropIndex("dbo.EmployeeLanguages", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeLanguages");
        }
    }
}
