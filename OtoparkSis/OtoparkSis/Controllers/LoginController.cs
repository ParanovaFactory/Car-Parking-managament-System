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
    public class LoginController : Controller
    {
        // GET: Login
        DbOtoparkEntities db = new DbOtoparkEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Tbl_Personel p)
        {
            var blg = db.Tbl_Personel.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (blg != null)
            {
                FormsAuthentication.SetAuthCookie(blg.KullaniciAdi, false);
                Session["Ad"] = blg.Ad.ToString();
                return RedirectToAction("Index", "AnaSayfa");
            }
            else
            {
                return View();
            }
        }
    }
}