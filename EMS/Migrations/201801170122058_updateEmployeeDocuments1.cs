namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeDocuments1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeDocuments", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDocuments", "FilePath", c => c.String(nullable: false));
        }
    }
}
