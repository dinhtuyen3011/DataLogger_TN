namespace DataLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chanels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OldDatas",
                c => new
                    {
                        Ms = c.Int(nullable: false, identity: true),
                        oldTime = c.DateTime(nullable: false),
                        ChanelId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Ms)
                .ForeignKey("dbo.Chanels", t => t.ChanelId, cascadeDelete: true)
                .Index(t => t.ChanelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OldDatas", "ChanelId", "dbo.Chanels");
            DropIndex("dbo.OldDatas", new[] { "ChanelId" });
            DropTable("dbo.OldDatas");
            DropTable("dbo.Chanels");
        }
    }
}
