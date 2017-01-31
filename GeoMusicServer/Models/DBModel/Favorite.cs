using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoMusicServer.Models.DBModel
{
    public class Favorite: Entity
    {
        public virtual ApplicationUser UserId { get; set; }
        public virtual Record RecordId { get; set; }
    }
}