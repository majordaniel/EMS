namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeSkill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        Details = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.EmployeeId)
                .Index(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.EmployeeSkills", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeSkills", new[] { "SkillId" });
            DropIndex("dbo.EmployeeSkills", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeSkills");
        }
    }
}
