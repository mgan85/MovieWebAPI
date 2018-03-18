namespace MovieWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "AverageRating", c => c.Double());
            AlterColumn("dbo.Rates", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rates", "Rating", c => c.Double(nullable: false));
            AlterColumn("dbo.Movies", "AverageRating", c => c.Double(nullable: false));
        }
    }
}
