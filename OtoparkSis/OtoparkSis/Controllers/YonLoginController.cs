using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtoparkSis.Models.Entity;
using System.Web.Security;

namespace OtoparkSis.Controllers
{
    [AllowAnonymous]
    public class YonLoginController : Controller
    {
        // GET: YonLogin
        DbOtoparkEntities db = new DbOtoparkEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Tbl_Yonetici y)
        {
            var blg = db.Tbl_Yonetici.FirstOrDefault(x => x.KullaniciAdi == y.KullaniciAdi && x.Sifre == y.Sifre);
            if (blg != null)
            {
                FormsAuthentication.SetAuthCookie(blg.KullaniciAdi, false);
                Session["Ad"] = blg.AdSoyad.ToString();
                return RedirectToAction("Index", "Yonetici");
            }
            else
            {
                return View();
            }
        }
    }
}