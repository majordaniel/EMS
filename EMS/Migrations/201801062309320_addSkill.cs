namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSkill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SkillName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Skills", new[] { "SkillName" });
            DropTable("dbo.Skills");
        }
    }
}
