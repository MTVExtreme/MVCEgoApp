namespace PersonalityEgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skill", "Role_RoleID", c => c.Int());
            CreateIndex("dbo.Skill", "Role_RoleID");
            AddForeignKey("dbo.Skill", "Role_RoleID", "dbo.Role", "RoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skill", "Role_RoleID", "dbo.Role");
            DropIndex("dbo.Skill", new[] { "Role_RoleID" });
            DropColumn("dbo.Skill", "Role_RoleID");
        }
    }
}
