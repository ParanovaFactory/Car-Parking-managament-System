using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtoparkSis.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
    }
}