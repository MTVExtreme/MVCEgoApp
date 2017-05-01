namespace PersonalityEgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charge",
                c => new
                    {
                        ChargeID = c.Int(nullable: false, identity: true),
                        ChargeName = c.String(),
                    })
                .PrimaryKey(t => t.ChargeID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Members = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Personality",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Gender = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        MentalAge = c.Int(),
                        Trial_TrialID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Trial", t => t.Trial_TrialID)
                .Index(t => t.RoleID)
                .Index(t => t.Trial_TrialID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Trial",
                c => new
                    {
                        TrialID = c.Int(nullable: false, identity: true),
                        ChargeID = c.Int(nullable: false),
                        TrialDate = c.DateTime(),
                        Result = c.Boolean(),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrialID)
                .ForeignKey("dbo.Charge", t => t.ChargeID, cascadeDelete: true)
                .Index(t => t.ChargeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personality", "Trial_TrialID", "dbo.Trial");
            DropForeignKey("dbo.Trial", "ChargeID", "dbo.Charge");
            DropForeignKey("dbo.Personality", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Role", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Trial", new[] { "ChargeID" });
            DropIndex("dbo.Role", new[] { "DepartmentID" });
            DropIndex("dbo.Personality", new[] { "Trial_TrialID" });
            DropIndex("dbo.Personality", new[] { "RoleID" });
            DropTable("dbo.Trial");
            DropTable("dbo.Role");
            DropTable("dbo.Personality");
            DropTable("dbo.Department");
            DropTable("dbo.Charge");
        }
    }
}
