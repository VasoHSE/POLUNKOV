namespace Main_Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedReferences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineGraphs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Describtion = c.String(maxLength: 512),
                        WebQuery = c.String(nullable: false, maxLength: 256),
                        Positives = c.Int(nullable: false),
                        Negatives = c.Int(nullable: false),
                        Koeficients = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LineGraphs");
        }
    }
}
