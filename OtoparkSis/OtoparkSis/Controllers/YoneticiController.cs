using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtoparkSis.Models.Entity;
using System.Web.Security;

namespace OtoparkSis.Controllers
{
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        public ActionResult Index()
        {
            var deger1 = db.Tbl_Arac.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.Tbl_Musteri.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.Tbl_Park.Sum(x => x.Fiyat);
            ViewBag.dgr3 = deger3;
            var deger4 = db.Tbl_Personel.Count();
            ViewBag.dgr4 = deger4;
            var deger5 = db.Tbl_Park.Where(x => x.Durum == true).Count();
            ViewBag.dgr5 = deger5;
            var deger6 = db.tbl_Alanlar.Where(x => x.Durum == true).Count();
            ViewBag.dgr6 = deger6;
            var deger7 = db.ENAKTİFUYE().FirstOrDefault();
            ViewBag.dgr7 = deger7;
            var deger8 = db.UYEARACSAYİSİ().FirstOrDefault();
            ViewBag.dgr8 = deger8;
            var deger9 = db.ENBASARİLİPER().FirstOrDefault();
            ViewBag.dgr9 = deger9;
            var deger10 = db.BUGUNİSLEM().FirstOrDefault();
            ViewBag.dgr10 = deger10;
            return View();
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","YonLogin");
        }
    }
}