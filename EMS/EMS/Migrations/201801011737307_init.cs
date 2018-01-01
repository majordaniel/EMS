namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(nullable: false, maxLength: 5),
                        CountryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CountryCode, unique: true)
                .Index(t => t.CountryName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Countries", new[] { "CountryName" });
            DropIndex("dbo.Countries", new[] { "CountryCode" });
            DropTable("dbo.Countries");
        }
    }
}
