namespace KMA.APZRPMJ2018.NumberConverter.DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Email = c.String(),
                    Login = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    LastLoginDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Guid);

            CreateTable(
                "dbo.Conversion",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    ArabNumeralValue = c.String(nullable: false),
                    RomanNumeralValue = c.String(nullable: false),
                    CoversionDate = c.Long(nullable: false),
                    UserGuid = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.UserGuid, cascadeDelete: true)
                .Index(t => t.UserGuid);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Conversion", "UserGuid", "dbo.Users");
            DropIndex("dbo.Conversion", new[] { "UserGuid" });
            DropTable("dbo.Conversion");
            DropTable("dbo.Conversion");
        }
    }
}