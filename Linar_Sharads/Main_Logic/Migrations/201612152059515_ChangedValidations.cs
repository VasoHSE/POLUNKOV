namespace Main_Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LineGraphs", "Name", c => c.String());
            AlterColumn("dbo.LineGraphs", "Describtion", c => c.String());
            AlterColumn("dbo.LineGraphs", "WebQuery", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LineGraphs", "WebQuery", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.LineGraphs", "Describtion", c => c.String(maxLength: 512));
            AlterColumn("dbo.LineGraphs", "Name", c => c.String(maxLength: 100));
        }
    }
}
