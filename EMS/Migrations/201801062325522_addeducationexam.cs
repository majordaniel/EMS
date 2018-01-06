namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeducationexam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EducationName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EducationName, unique: true);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamName = c.String(nullable: false, maxLength: 100),
                        EducationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId)
                .Index(t => t.ExamName, unique: true)
                .Index(t => t.EducationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "EducationId", "dbo.Educations");
            DropIndex("dbo.Exams", new[] { "EducationId" });
            DropIndex("dbo.Exams", new[] { "ExamName" });
            DropIndex("dbo.Educations", new[] { "EducationName" });
            DropTable("dbo.Exams");
            DropTable("dbo.Educations");
        }
    }
}
