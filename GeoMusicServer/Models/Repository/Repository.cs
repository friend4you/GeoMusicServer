using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GeoMusicServer.Models.DBModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GeoMusicServer.Models
{
    public class Repository
    {
        ApplicationDbContext db;

        public Repository()
        {
            db = new ApplicationDbContext();
        }


        #region // User CRUD
       
        public List<ApplicationUser> GetUsers
        {
            get { return db.Users.ToList<ApplicationUser>(); }
        }

        public ApplicationUser GetUser(string id)
        {
            
            return db.Users.Find(id);
        }

        public List<ApplicationUser> GetUserEmail(string email)
        {
            ApplicationUser user = db.Users.Where(u => u.Email == email).FirstOrDefault();
            List<ApplicationUser> list = new List<ApplicationUser>();
            list.Add(user);
            return list;
        }

        public List<string> LoginFailure()
        {
            List<string> list = new List<string>();
            list.Add("failed");
            return list;
        }

        public void EditUser(ApplicationUser user)
        {
            db.Entry(user).State = EntityState.Modified;



            db.SaveChanges();
        }

        public void CreateUser(ApplicationUser user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
        }

        #endregion

        #region // Records CRUD

        public List<Record> GetRecords
        {
            get { return db.Records.ToList<Record>(); }
        }

        public Record GetRecord(string id)
        {
            return db.Records.Find(id);
        }

        public void EditRecord(Record record)
        {
            db.Entry(record).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateRecord(Record record)
        {
            db.Records.Add(record);
            db.SaveChanges();
        }

        public void DeleteRecord(string id)
        {
            db.Records.Remove(db.Records.Find(id));
            db.SaveChanges();
        }


        #endregion

        #region // Playlists CRUD

        public List<Playlist> GetPlaylists
        {
            get { return db.Playlists.ToList<Playlist>(); }
        }

        public Playlist GetPlaylist(string id)
        {
            return db.Playlists.Find(id);
        }

        public void EditPlaylist(Playlist playlist)
        {
            db.Entry(playlist).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreatePlaylist(Playlist playlist)
        {
            db.Playlists.Add(playlist);
            db.SaveChanges();
        }

        public void DeletePlaylist(string id)
        {
            db.Playlists.Remove(db.Playlists.Find(id));
            db.SaveChanges();
        }

        #endregion

        #region // Category CRUD

        public List<Category> GetCategories
        {
            get { return db.Categories.ToList<Category>(); }
        }

        public Category GetCategory(string id)
        {
            return db.Categories.Find(id);
        }

        public void EditCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(string id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
        }

        #endregion

        #region // Role CRUD

        public List<IdentityRole> GetRoles
        {
            get { return db.Roles.ToList<IdentityRole>(); }
        }

        public IdentityRole GetRole(string id)
        {
            return db.Roles.Find(id);
        }

        public void EditRole(IdentityRole role)
        {
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateRole(IdentityRole role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public void DeleteRole(string id)
        {
            db.Roles.Remove(db.Roles.Find(id));
            db.SaveChanges();
        }

        #endregion
    }
}