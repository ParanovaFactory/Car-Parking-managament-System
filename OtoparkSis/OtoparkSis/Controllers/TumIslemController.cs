using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtoparkSis.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace OtoparkSis.Controllers
{
    public class TumIslemController : Controller
    {
        // GET: TumIslem
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        public ActionResult Index(int kayit = 1)
        {
            var kyt = db.Tbl_Park.ToList().ToPagedList(kayit, 5);
            return View(kyt);
        }
    }
}