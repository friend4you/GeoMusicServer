using GeoMusicSiteClient.Models;
using GeoMusicSiteClient.Models.DBModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GeoMusicSiteClient.Controllers.api
{
    public class AdminController : Controller
    {
        Repository db = new Repository();
        // GET: Admin
        //[Authorize(Roles = "admin, moderator")]
        public ActionResult Index()
        {
            ViewBag.Users = db.GetUsers;
            ViewBag.Records = db.GetRecords;
            ViewBag.Playlists = db.GetPlaylists;
            ViewBag.Categories = db.GetCategories;
            return View();
        }

        public ActionResult Roles()
        {
            ViewBag.Roles = db.GetRoles;
            return View(new IdentityRole());
        }

        [HttpPost]
        public ActionResult Roles(IdentityRole role)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                db.CreateRole(role);
                ViewBag.Roles = db.GetRoles;
            }
            catch
            {
                return View();
            }
            return View();
        }
        public ActionResult DeleteRole(String id)
        {
            try
            {
                db.DeleteRole(id);
                ViewBag.Roles = db.GetRoles;
            }
            catch
            {
                return new RedirectResult("/admin/Roles");
            }

            return new RedirectResult("/admin/Roles");
        }

        public ActionResult Users()
        {
            ViewBag.Users = db.GetUsers;
            ViewBag.Categories = db.GetCategories;
            return View(new ApplicationUser());
        }
        public ActionResult Playlists()
        {
            ViewBag.Playlists = db.GetPlaylists;
            return View();
        }
        public ActionResult Records()
        {
            ViewBag.Records = db.GetRecords;
            return View(new Record());
        }
        [HttpPost]
        public ActionResult Records(Record record, string Lat, string Long)
        {
            record.AddDate = DateTime.Now;
            record.Lat = Convert.ToDouble(Lat.Replace('.', ','));
            record.Long = Convert.ToDouble(Long.Replace('.', ','));
            try
            {
                db.CreateRecord(record);
                record = db.GetLastRecord();
            }
            catch { }
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string folderName = "~/App_Data/Images/Records/";
                    string pathString = Path.Combine(folderName, record.id.ToString());
                    var path = Path.Combine(Server.MapPath(pathString), fileName);
                    var pathToCreate = Path.Combine(Server.MapPath(pathString));
                    Directory.CreateDirectory(pathToCreate);
                    file.SaveAs(path);
                    db.AddRecordImage(record, path);
                }
            }
            ViewBag.Records = db.GetRecords;
            return View();
        }
        public ActionResult Categories()
        {
            ViewBag.Categories = db.GetCategories;
            return View(new Category());
        }
        [HttpPost]
        public ActionResult Categories(Category category, Color catColor)
        {
            
            //Category category = new Category();
            //category.Name = Name;
            //category.Description = Description;
            category.Color = catColor.R.ToString("X2") + catColor.G.ToString("X2") + catColor.B.ToString("X2");
            try
            {
                db.CreateCategory(category);
                category = db.GetLastCategory();
            }
            catch { }            
            if (Request.Files.Count > 0)
            {
                 
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string path = new BLL.BlobStorage().StorageImageCategory(file);                
                    db.AddCategoryImage(category.id, path);
                }                
            }
            ViewBag.Categories = db.GetCategories;
            return View();
        }
        public ActionResult DeleteCategory(string id)
        {
            try
            {
                db.DeleteCategory(id);
                ViewBag.Categories = db.GetCategories;
            }
            catch
            {
                return new RedirectResult("/admin/Categories");
            }

            return new RedirectResult("/admin/Categories");
        }
        public ActionResult Edit()
        {            
            return View();
        }
        public RedirectResult Delete()
        {
            return new RedirectResult("/Admin/Index");
        }
    }
}