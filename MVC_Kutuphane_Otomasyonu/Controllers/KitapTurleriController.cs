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
    public class KitapTurleriController : Controller
    {
        // GET: KitapTurleri
        KutuphaneContext context = new KutuphaneContext();
        KitapTurleriDAL kitapTurleriDAL = new KitapTurleriDAL();
        public ActionResult Index()
        {
            var model = kitapTurleriDAL.GetAll(context);
            return View(model); ;
        }
        //get
        public ActionResult Ekle() 
        {
            return View(new KitapTurleri());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Ekle(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)
            {
                kitapTurleri.Aciklama = kitapTurleri.Aciklama ?? "";
                kitapTurleriDAL.insertupdate(context, kitapTurleri);
                kitapTurleriDAL.save(context);
                return RedirectToAction("Index");
            }
            return View(kitapTurleri);
        }

    }
}