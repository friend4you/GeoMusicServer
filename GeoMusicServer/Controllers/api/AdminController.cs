using GeoMusicServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GeoMusicServer.Controllers.api
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
            return View();
        }
        public ActionResult Users()
        {
            ViewBag.Users = db.GetUsers;
            return View();
        }
        public ActionResult Playlists()
        {
            ViewBag.Playlists = db.GetPlaylists;
            return View();
        }
        public ActionResult Records()
        {
            ViewBag.Records = db.GetRecords;
            return View();
        }
        public ActionResult Categories()
        {
            ViewBag.Categories = db.GetCategories;
            return View();
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