using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webOgrenci.Models.EntityFramework;

namespace webOgrenci.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbOgrEntities db = new DbOgrEntities();
        public ActionResult Index()
        {
            var dersler = db.TBL_DERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBL_DERSLER p)
        {
            db.TBL_DERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var drs = db.TBL_DERSLER.Find(id);
            db.TBL_DERSLER.Remove(drs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.TBL_DERSLER.Find(id);
            return View("DersGetir",ders);
        }
        public ActionResult Guncelle(TBL_DERSLER p)
        {
            var ders = db.TBL_DERSLER.Find(p.DERSID);
            ders.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}