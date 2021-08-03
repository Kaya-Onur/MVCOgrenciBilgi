using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webOgrenci.Models.EntityFramework;

namespace webOgrenci.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbOgrEntities db = new DbOgrEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBL_OGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBL_OGRENCILER p)
        {
            var klp = db.TBL_KULUPLER.Where(m => m.KULUPID == p.TBL_KULUPLER.KULUPID).FirstOrDefault();
            p.TBL_KULUPLER = klp;
            db.TBL_OGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogr = db.TBL_OGRENCILER.Find(id);
            db.TBL_OGRENCILER.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.TBL_OGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_KULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogr);
        }
        public ActionResult Guncelle(TBL_OGRENCILER p)
        {
            var ogr = db.TBL_OGRENCILER.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP =p.OGRKULUP;
            ogr.OGRFOTOGRAF = p.OGRFOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Action", Value = "0" });

//items.Add(new SelectListItem { Text = "Drama", Value = "1" });

//items.Add(new SelectListItem { Text = "Comedy", Value = "2" });

//items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

//ViewBag.DersAd = items;