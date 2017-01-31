namespace GeoMusicServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Color");
        }
    }
}
