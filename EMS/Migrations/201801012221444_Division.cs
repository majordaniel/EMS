namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Division : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        DivisionCode = c.String(nullable: false, maxLength: 5),
                        DivisionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.DivisionCode, unique: true)
                .Index(t => t.DivisionName, unique: true);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Division_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.Division_Id)
                .Index(t => t.Division_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Districts", "Division_Id", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Districts", new[] { "Division_Id" });
            DropIndex("dbo.Divisions", new[] { "DivisionName" });
            DropIndex("dbo.Divisions", new[] { "DivisionCode" });
            DropIndex("dbo.Divisions", new[] { "CountryId" });
            DropTable("dbo.Districts");
            DropTable("dbo.Divisions");
        }
    }
}
