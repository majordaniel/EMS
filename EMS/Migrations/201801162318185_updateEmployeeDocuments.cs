namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeDocuments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeDocuments", "FilePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDocuments", "FilePath", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
