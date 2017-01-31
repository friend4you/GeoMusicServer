using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoMusicServer.Controllers.api
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult CreatePlaylist()
        {
            return new RedirectResult("/Admin/Playlists");
        }
    }
}