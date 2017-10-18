namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movievalidation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyUsers", "Password", c => c.String());
            AlterColumn("dbo.MyUsers", "Login", c => c.String());
            AlterColumn("dbo.MyUsers", "Name", c => c.String());
        }
    }
}
