namespace DB_Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 100),
                        Describtion = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.LineGraphs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Describtion = c.String(maxLength: 256),
                        WebQuery = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.Name, cascadeDelete: true)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Describtion = c.String(maxLength: 256),
                        StartValue = c.Single(nullable: false),
                        EndValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.ResultLineGraphs",
                c => new
                    {
                        Result_Id = c.Int(nullable: false),
                        LineGraph_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Result_Id, t.LineGraph_Id })
                .ForeignKey("dbo.Results", t => t.Result_Id, cascadeDelete: true)
                .ForeignKey("dbo.LineGraphs", t => t.LineGraph_Id, cascadeDelete: true)
                .Index(t => t.Result_Id)
                .Index(t => t.LineGraph_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultLineGraphs", "LineGraph_Id", "dbo.LineGraphs");
            DropForeignKey("dbo.ResultLineGraphs", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.Results", "Name", "dbo.Areas");
            DropForeignKey("dbo.LineGraphs", "Name", "dbo.Areas");
            DropIndex("dbo.ResultLineGraphs", new[] { "LineGraph_Id" });
            DropIndex("dbo.ResultLineGraphs", new[] { "Result_Id" });
            DropIndex("dbo.Results", new[] { "Name" });
            DropIndex("dbo.LineGraphs", new[] { "Name" });
            DropTable("dbo.ResultLineGraphs");
            DropTable("dbo.Results");
            DropTable("dbo.LineGraphs");
            DropTable("dbo.Areas");
        }
    }
}
