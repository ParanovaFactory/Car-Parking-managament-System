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
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        public ActionResult Index(int kayit = 1)
        {
            var mus = db.Tbl_Musteri.Where(x => x.Durum == true).ToList().ToPagedList(kayit, 5);
            return View(mus);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Tbl_Musteri k)
        {
            k.Durum = true;
            db.Tbl_Musteri.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(Tbl_Musteri k)
        {
            var mus = db.Tbl_Musteri.Find(k.Id);
            mus.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            var mus = db.Tbl_Musteri.Find(id);
            return View("Getir", mus);
        }
        public ActionResult MusteriGuncelle(Tbl_Musteri k)
        {
            var mus = db.Tbl_Musteri.Find(k.Id);
            mus.AdSoyad = k.AdSoyad;
            mus.Telefon = k.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}