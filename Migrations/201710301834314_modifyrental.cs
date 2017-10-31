namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyrental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "CustomersId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "MoviesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "MoviesId");
            DropColumn("dbo.Rentals", "CustomersId");
        }
    }
}
