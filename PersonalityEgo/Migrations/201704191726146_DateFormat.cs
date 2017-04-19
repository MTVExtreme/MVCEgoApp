namespace PersonalityEgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateFormat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personality", "MyProperty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personality", "MyProperty");
        }
    }
}
