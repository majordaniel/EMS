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
                        DivisionId = c.Int(nullable: false),
                        DistrictCode = c.String(nullable: false, maxLength: 5),
                        DistrictName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .Index(t => t.DivisionId)
                .Index(t => t.DistrictCode, unique: true)
                .Index(t => t.DistrictName, unique: true);
            
            CreateTable(
                "dbo.PoliceStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        PoliceStationCode = c.String(nullable: false, maxLength: 5),
                        PoliceStationName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .Index(t => t.DistrictId)
                .Index(t => t.PoliceStationCode, unique: true)
                .Index(t => t.PoliceStationName, unique: true);
            
            CreateTable(
                "dbo.Unions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PoliceStationId = c.Int(nullable: false),
                        UnionCode = c.String(nullable: false, maxLength: 5),
                        UnionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoliceStations", t => t.PoliceStationId)
                .Index(t => t.PoliceStationId)
                .Index(t => t.UnionCode, unique: true)
                .Index(t => t.UnionName, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 5),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DepartmentCode, unique: true)
                .Index(t => t.DepartmentName, unique: true);
            
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
            DropForeignKey("dbo.Unions", "PoliceStationId", "dbo.PoliceStations");
            DropForeignKey("dbo.PoliceStations", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Designations", new[] { "DesignationName" });
            DropIndex("dbo.Designations", new[] { "DesignationCode" });
            DropIndex("dbo.Departments", new[] { "DepartmentName" });
            DropIndex("dbo.Departments", new[] { "DepartmentCode" });
            DropIndex("dbo.Unions", new[] { "UnionName" });
            DropIndex("dbo.Unions", new[] { "UnionCode" });
            DropIndex("dbo.Unions", new[] { "PoliceStationId" });
            DropIndex("dbo.PoliceStations", new[] { "PoliceStationName" });
            DropIndex("dbo.PoliceStations", new[] { "PoliceStationCode" });
            DropIndex("dbo.PoliceStations", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "DistrictName" });
            DropIndex("dbo.Districts", new[] { "DistrictCode" });
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropIndex("dbo.Divisions", new[] { "DivisionName" });
            DropIndex("dbo.Divisions", new[] { "DivisionCode" });
            DropIndex("dbo.Divisions", new[] { "CountryId" });
            DropIndex("dbo.Countries", new[] { "CountryName" });
            DropIndex("dbo.Countries", new[] { "CountryCode" });
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Unions");
            DropTable("dbo.PoliceStations");
            DropTable("dbo.Districts");
            DropTable("dbo.Divisions");
            DropTable("dbo.Countries");
        }
    }
}
