namespace GeoMusicServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecordId_id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Records", t => t.RecordId_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.RecordId_id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PlaylistId_id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.PlaylistId_id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscribes", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscribes", "PlaylistId_id", "dbo.Playlists");
            DropForeignKey("dbo.Favorites", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "RecordId_id", "dbo.Records");
            DropIndex("dbo.Subscribes", new[] { "UserId_Id" });
            DropIndex("dbo.Subscribes", new[] { "PlaylistId_id" });
            DropIndex("dbo.Favorites", new[] { "UserId_Id" });
            DropIndex("dbo.Favorites", new[] { "RecordId_id" });
            DropTable("dbo.Subscribes");
            DropTable("dbo.Favorites");
        }
    }
}
