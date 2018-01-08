namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLanguageCertification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CertificationName = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CertificationName, unique: true);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageCode = c.String(nullable: false, maxLength: 3),
                        LanguageName = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.LanguageCode, unique: true)
                .Index(t => t.LanguageName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Languages", new[] { "LanguageName" });
            DropIndex("dbo.Languages", new[] { "LanguageCode" });
            DropIndex("dbo.Certifications", new[] { "CertificationName" });
            DropTable("dbo.Languages");
            DropTable("dbo.Certifications");
        }
    }
}
