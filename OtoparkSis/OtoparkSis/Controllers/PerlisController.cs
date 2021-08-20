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
    public class PerlisController : Controller
    {
        // GET: Perlis
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        public ActionResult Index(int kisi=1)
        {
            var per = db.Tbl_Personel.Where(x => x.Durum == true).ToList().ToPagedList(kisi,13);
            return View(per);
        }
    }
}