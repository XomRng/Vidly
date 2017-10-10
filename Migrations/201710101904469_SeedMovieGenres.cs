namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres ( Name) VALUES ( 'Horror')");
            Sql("INSERT INTO MovieGenres ( Name) VALUES ( 'Comedy')");
            Sql("INSERT INTO MovieGenres ( Name) VALUES ( 'Serial')");
            Sql("INSERT INTO MovieGenres ( Name) VALUES ( 'Thriller')");
            Sql("INSERT INTO MovieGenres ( Name) VALUES ( 'Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
