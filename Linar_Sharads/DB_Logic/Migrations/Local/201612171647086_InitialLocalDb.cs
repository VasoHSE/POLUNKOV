using System.Data.Entity.Migrations;

namespace DB_Logic.Migrations.Local
{
    public partial class InitialLocalDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineGraphs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Describtion = c.String(nullable: false),
                        WebQuery = c.String(nullable: false, maxLength: 512),
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
