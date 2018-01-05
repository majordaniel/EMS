namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        FathersName = c.String(nullable: false, maxLength: 100),
                        MothersName = c.String(nullable: false, maxLength: 100),
                        MaritalStatus = c.Int(nullable: false),
                        SpouseName = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        BloodGroup = c.Int(nullable: false),
                        Religion = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Mobile = c.String(nullable: false, maxLength: 20),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        NationalID = c.String(nullable: false, maxLength: 17),
                        HouseNo = c.String(nullable: false),
                        RoadNo = c.String(nullable: false),
                        Village = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        PoliceStationId = c.Int(nullable: false),
                        UnionId = c.Int(nullable: false),
                        PostalCode = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        EmployementStatus = c.Int(nullable: false),
                        PayGrade = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        EmployeeRegNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .ForeignKey("dbo.PoliceStations", t => t.PoliceStationId)
                .ForeignKey("dbo.Unions", t => t.UnionId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Mobile, unique: true)
                .Index(t => t.NationalID, unique: true)
                .Index(t => t.CountryId)
                .Index(t => t.DivisionId)
                .Index(t => t.DistrictId)
                .Index(t => t.PoliceStationId)
                .Index(t => t.UnionId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UnionId", "dbo.Unions");
            DropForeignKey("dbo.Employees", "PoliceStationId", "dbo.PoliceStations");
            DropForeignKey("dbo.Employees", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "CountryId", "dbo.Countries");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "UnionId" });
            DropIndex("dbo.Employees", new[] { "PoliceStationId" });
            DropIndex("dbo.Employees", new[] { "DistrictId" });
            DropIndex("dbo.Employees", new[] { "DivisionId" });
            DropIndex("dbo.Employees", new[] { "CountryId" });
            DropIndex("dbo.Employees", new[] { "NationalID" });
            DropIndex("dbo.Employees", new[] { "Mobile" });
            DropIndex("dbo.Employees", new[] { "Email" });
            DropTable("dbo.Employees");
        }
    }
}
