namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDocuments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DocumentType, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Documents", new[] { "DocumentType" });
            DropTable("dbo.Documents");
        }
    }
}
