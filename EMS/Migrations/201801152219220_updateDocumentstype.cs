namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDocumentstype : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Documents", new[] { "DocumentType" });
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TypeName, unique: true);
            
            DropTable("dbo.Documents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.DocumentTypes", new[] { "TypeName" });
            DropTable("dbo.DocumentTypes");
            CreateIndex("dbo.Documents", "DocumentType", unique: true);
        }
    }
}
