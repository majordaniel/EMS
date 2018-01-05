namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ContactPerson", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employees", "ContactMobileNo", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Employees", "ContactEmail", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Employees", "ContactRelation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ContactRelation");
            DropColumn("dbo.Employees", "ContactEmail");
            DropColumn("dbo.Employees", "ContactMobileNo");
            DropColumn("dbo.Employees", "ContactPerson");
        }
    }
}
