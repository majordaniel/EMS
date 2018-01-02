namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddistrictpolicestaionunion : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Districts", new[] { "Division_Id" });
            RenameColumn(table: "dbo.Districts", name: "Division_Id", newName: "DivisionId");
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
            
            AddColumn("dbo.Districts", "DistrictCode", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Districts", "DistrictName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Districts", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Districts", "DivisionId");
            CreateIndex("dbo.Districts", "DistrictCode", unique: true);
            CreateIndex("dbo.Districts", "DistrictName", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Unions", "PoliceStationId", "dbo.PoliceStations");
            DropForeignKey("dbo.PoliceStations", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Unions", new[] { "UnionName" });
            DropIndex("dbo.Unions", new[] { "UnionCode" });
            DropIndex("dbo.Unions", new[] { "PoliceStationId" });
            DropIndex("dbo.PoliceStations", new[] { "PoliceStationName" });
            DropIndex("dbo.PoliceStations", new[] { "PoliceStationCode" });
            DropIndex("dbo.PoliceStations", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "DistrictName" });
            DropIndex("dbo.Districts", new[] { "DistrictCode" });
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            AlterColumn("dbo.Districts", "DivisionId", c => c.Int());
            DropColumn("dbo.Districts", "DistrictName");
            DropColumn("dbo.Districts", "DistrictCode");
            DropTable("dbo.Unions");
            DropTable("dbo.PoliceStations");
            RenameColumn(table: "dbo.Districts", name: "DivisionId", newName: "Division_Id");
            CreateIndex("dbo.Districts", "Division_Id");
        }
    }
}
