using System.Data.Entity.Migrations;

namespace DB_Logic.Migrations.Azure
{
    public partial class InitialAzureDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Describtion = c.String(nullable: false),
                        Picture = c.Binary(),
                        LineGraphName = c.String(),
                        LineGraphDescribtion = c.String(),
                        LineGraphWebQuery = c.String(nullable: false, maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Results");
        }
    }
}
