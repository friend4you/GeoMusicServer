namespace GeoMusicServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newtabels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Subscribe = c.Int(nullable: false),
                        Category_id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.Category_id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Artist = c.String(),
                        Description = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        Url = c.String(),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        Image = c.String(),
                        Playlist_id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Playlist_id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surnname", c => c.String());
            AddColumn("dbo.AspNetUsers", "VkToken", c => c.String());
            AddColumn("dbo.AspNetUsers", "GoogleToken", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Playlists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Records", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Records", "Playlist_id", "dbo.Playlists");
            DropForeignKey("dbo.Playlists", "Category_id", "dbo.Categories");
            DropIndex("dbo.Records", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Records", new[] { "Playlist_id" });
            DropIndex("dbo.Playlists", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Playlists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Playlists", new[] { "Category_id" });
            DropIndex("dbo.Categories", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "GoogleToken");
            DropColumn("dbo.AspNetUsers", "VkToken");
            DropColumn("dbo.AspNetUsers", "Surnname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Records");
            DropTable("dbo.Playlists");
            DropTable("dbo.Categories");
        }
    }
}
