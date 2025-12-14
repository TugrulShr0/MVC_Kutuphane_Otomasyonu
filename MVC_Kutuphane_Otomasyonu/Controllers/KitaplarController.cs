using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{
    [Authorize(Roles ="Admin,Moderatör")]
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        KutuphaneContext context = new KutuphaneContext();
        KitaplarDAL KitaplarDal = new KitaplarDAL();
        public ActionResult Index()
        {
            var model = KitaplarDal.GetAll(context,null,"KitapTurleri");
            return View(model);
        }
        public ActionResult Ekle()
        {
            ViewBag.liste= new SelectList(context.KitapTurleri,"ID","KitapTuru");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Ekle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.KitapTurleri, "ID", "KitapTuru");
                return View(entity);
            }

            context.Kitaplar.Add(entity);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Duzenle(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            ViewBag.liste = new SelectList(context.KitapTurleri, "ID", "KitapTuru");
            var model = KitaplarDal.GetByFilter(context, x => x.ID == id,"KitapTurleri");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Duzenle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.KitapTurleri, "ID", "KitapTuru");
                return View(entity);
            }

            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detay(int? id) 
        { 
            var model = KitaplarDal.GetByFilter(context, x => x.ID == id,"KitapTurleri");
            return View(model);

        }
        public ActionResult Sil(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var model = KitaplarDal.GetByFilter(context, x => x.ID == id);
            context.Kitaplar.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}