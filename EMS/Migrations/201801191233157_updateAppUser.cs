namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAppUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AppUsers", new[] { "UserName" });
            AlterColumn("dbo.AppUsers", "UserName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AppUsers", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AppUsers", new[] { "UserName" });
            AlterColumn("dbo.AppUsers", "UserName", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.AppUsers", "UserName", unique: true);
        }
    }
}
