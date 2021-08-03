using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webOgrenci.Models.EntityFramework;
using webOgrenci.Models;

namespace webOgrenci.Controllers
{
    public class SinavNotlariController : Controller
    {
        // GET: SinavNotlari
        DbOgrEntities db = new DbOgrEntities();
        public ActionResult Index()
        {
            var notlar = db.TBL_NOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBL_NOTLAR p)
        {
            db.TBL_NOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var snv = db.TBL_NOTLAR.Find(id);

            return View("NotGetir", snv);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model,TBL_NOTLAR p,int SINAV1=0,int SINAV2=0,int SINAV3=0,int PROJE=0)
        {
            if (model.islem == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var snv = db.TBL_NOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}