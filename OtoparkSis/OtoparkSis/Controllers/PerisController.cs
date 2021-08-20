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
    public class PerisController : Controller
    {
        // GET: Perlis
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        public ActionResult Index(int kisi = 1)
        {
            var per = db.Tbl_Personel.Where(x => x.Durum == true).ToList().ToPagedList(kisi, 13);
            return View(per);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Personel k)
        {
            k.Durum = true;
            db.Tbl_Personel.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(Tbl_Personel k)
        {
            var per = db.Tbl_Personel.Find(k.Id);
            per.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            var per = db.Tbl_Personel.Find(id);
            return View("Getir", per);
        }
        public ActionResult Guncelle(Tbl_Personel k)
        {
            var per = db.Tbl_Personel.Find(k.Id);
            per.Ad = k.Ad;
            per.KullaniciAdi = k.KullaniciAdi;
            per.Sifre = k.Sifre;
            per.Telefon = k.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}