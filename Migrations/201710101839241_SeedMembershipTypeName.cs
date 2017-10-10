namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Jednorazowa zap³ata' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name='Miesiêczne' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name='Pó³roczne' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name='Roczne' WHERE Id = 4");


        }
        
        public override void Down()
        {
        }
    }
}
