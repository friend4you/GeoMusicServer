namespace GeoMusicServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1013 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Playlists", "Subscribe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlists", "Subscribe", c => c.Int(nullable: false));
        }
    }
}
