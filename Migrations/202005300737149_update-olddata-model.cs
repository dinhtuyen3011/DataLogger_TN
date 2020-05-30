namespace DataLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateolddatamodel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OldDatas");
            AlterColumn("dbo.OldDatas", "Ms", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OldDatas", new[] { "Ms", "ChanelId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OldDatas");
            AlterColumn("dbo.OldDatas", "Ms", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OldDatas", "Ms");
        }
    }
}
