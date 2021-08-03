using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webOgrenci.Models.EntityFramework;

namespace webOgrenci.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbOgrEntities db = new DbOgrEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBL_KULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBL_KULUPLER p)
        {
            db.TBL_KULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBL_KULUPLER.Find(id);
            db.TBL_KULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBL_KULUPLER.Find(id);

            return View("KulupGetir", kulup);
        }
        public ActionResult Guncelle(TBL_KULUPLER p)
        {
            var klp = db.TBL_KULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            klp.KULUPKONTJ = p.KULUPKONTJ;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}