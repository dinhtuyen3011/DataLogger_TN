namespace DataLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedchanels : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Chanels (Name) VALUES ('Chanel 1')");
            Sql("INSERT INTO Chanels (Name) VALUES ('Chanel 2')");
            Sql("INSERT INTO Chanels (Name) VALUES ('Chanel 3')");
            Sql("INSERT INTO Chanels (Name) VALUES ('Chanel 4')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Chanels");
        }
    }
}
