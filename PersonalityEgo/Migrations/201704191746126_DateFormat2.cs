namespace PersonalityEgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateFormat2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personality", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personality", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
