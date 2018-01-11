namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeTrainingHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTrainingHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TrainingTitle = c.String(nullable: false, maxLength: 100),
                        TrainingTopic = c.String(nullable: false, maxLength: 100),
                        TrainingInstitute = c.String(nullable: false, maxLength: 100),
                        IstituteLocation = c.String(nullable: false, maxLength: 25),
                        InstituteCountry = c.String(nullable: false, maxLength: 25),
                        TrainingYear = c.Int(nullable: false),
                        TrainingDuration = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTrainingHistories", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeTrainingHistories", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeTrainingHistories");
        }
    }
}
