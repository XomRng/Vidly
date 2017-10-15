namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusertypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MyUserTypes (Name) values ('Administrator')");
            Sql("INSERT INTO MyUserTypes (Name) values ('Moderator')");
            Sql("INSERT INTO MyUserTypes (Name) values ('MyUser')");

        }
        
        public override void Down()
        {
        }
    }
}
