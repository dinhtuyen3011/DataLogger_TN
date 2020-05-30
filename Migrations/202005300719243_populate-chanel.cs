namespace DataLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatechanel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chanels", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.OldDatas", "OldTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OldDatas", "OldTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Chanels", "Name", c => c.Int(nullable: false));
        }
    }
}
