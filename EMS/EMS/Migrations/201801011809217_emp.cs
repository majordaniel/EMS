namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
