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
    public class ParkGirisController : Controller
    {
        // GET: ParkGiris
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        public ActionResult Index(int kayit = 1)
        {
            var prk = db.Tbl_Park.Where(x => x.Durum == true).ToList().ToPagedList(kayit, 10);
            return View(prk);
        }
        public ActionResult Index1(int kayit = 1)
        {
            var prk = db.Tbl_Park.Where(x => x.Durum == true).ToList().ToPagedList(kayit, 10);
            return View(prk);
        }
        [HttpGet]
        public ActionResult ParkGirisi()
        {
            List<SelectListItem> deger1 = (from x in db.Tbl_Musteri.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AdSoyad,
                                               Value = x.Id.ToString()
                                           }
                                           ).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in db.Tbl_Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in db.Tbl_Arac.Where(y => y.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Plaka,
                                               Value = x.Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr3 = deger3;
            List<SelectListItem> deger4 = (from x in db.tbl_Alanlar.Where(y => y.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr4 = deger4;
            return View();
        }
        [HttpPost]
        public ActionResult ParkGirisi(Tbl_Park k)
        {
            var d1 = db.Tbl_Musteri.Where(x => x.Id == k.Tbl_Musteri.Id).FirstOrDefault();
            var d2 = db.Tbl_Personel.Where(x => x.Id == k.Tbl_Personel.Id).FirstOrDefault();
            var d3 = db.Tbl_Arac.Where(x => x.Id == k.Tbl_Arac.Id).FirstOrDefault();
            var d4 = db.tbl_Alanlar.Where(x => x.Id == k.tbl_Alanlar.Id).FirstOrDefault();
            k.Tbl_Musteri = d1;
            k.Tbl_Personel = d2;
            k.Tbl_Arac = d3;
            k.tbl_Alanlar = d4;
            db.Tbl_Park.Add(k);
            k.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ParkCikisi(Tbl_Park k)
        {
            var cks = db.Tbl_Park.Find(k.Id);
            DateTime d1 = DateTime.Parse(cks.GirisTarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr7 = Convert.ToInt32(d3.TotalHours);
            return View("ParkCikisi", cks);
        }
        public ActionResult Cikar(Tbl_Park k)
        {
            var cks = db.Tbl_Park.Find(k.Id);
            cks.ÇikisTarihi = k.ÇikisTarihi;
            cks.Fiyat = k.Fiyat;
            cks.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}