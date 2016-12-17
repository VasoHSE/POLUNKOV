namespace DB_Logic.Migrations.Azure
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAzureDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Describtion = c.String(maxLength: 512),
                        StartValue = c.Single(nullable: false),
                        EndValue = c.Single(nullable: false),
                        Koeficients = c.String(nullable: false),
                        LineGraph_Name = c.String(maxLength: 100),
                        Line_Graph_Describtion = c.String(maxLength: 512),
                        LineGraph_WebQuery = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Results");
        }
    }
}
