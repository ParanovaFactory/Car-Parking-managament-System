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
    public class AracController : Controller
    {
        DbOtoparkEntities db = new DbOtoparkEntities();
        [Authorize]
        // GET: Admin
        public ActionResult Index(int kayit=1)
        {
            var arc = db.Tbl_Arac.Where(x => x.Durum2 == true).ToList().ToPagedList(kayit, 5);
            return View(arc);
        }
        [HttpGet]
        public ActionResult AracEkle()
        {
            List<SelectListItem> mus = (from x in db.Tbl_Musteri.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AdSoyad,
                                            Value = x.Id.ToString()
                                        }
                                        ).ToList();
            ViewBag.must = mus;
            return View();
        }
        [HttpPost]
        public ActionResult AracEkle(Tbl_Arac k)
        {
            var mus = db.Tbl_Musteri.Where(x => x.Id == k.Tbl_Musteri.Id).FirstOrDefault();
            k.Tbl_Musteri = mus;
            k.Durum = true;
            db.Tbl_Arac.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AracSil(Tbl_Arac k)
        {
            var arc = db.Tbl_Arac.Find(k.Id);
            arc.Durum2 = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir (int id)
        {
            List<SelectListItem> mus = (from x in db.Tbl_Musteri.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AdSoyad,
                                            Value = x.Id.ToString()
                                        }
                                       ).ToList();
            ViewBag.must = mus;
            var arc = db.Tbl_Arac.Find(id);
            return View("Getir", arc);
        }
        public ActionResult AracGuncelle(Tbl_Arac k)
        {
            var arc = db.Tbl_Arac.Find(k.Id);
            var arcs = db.Tbl_Musteri.Where(x => x.Id == arc.Tbl_Musteri.Id).FirstOrDefault();
            arc.Plaka = k.Plaka;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}