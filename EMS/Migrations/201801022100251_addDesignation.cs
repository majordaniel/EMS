namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDesignation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationCode = c.String(nullable: false, maxLength: 5),
                        DesignationName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DesignationCode, unique: true)
                .Index(t => t.DesignationName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Designations", new[] { "DesignationName" });
            DropIndex("dbo.Designations", new[] { "DesignationCode" });
            DropTable("dbo.Designations");
        }
    }
}
