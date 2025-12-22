using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{

    [Authorize]
    public class KitapTurleriController : Controller
    {
        // GET: KitapTurleri
        KutuphaneContext context = new KutuphaneContext();
        KitapTurleriDAL kitapTurleriDAL = new KitapTurleriDAL();
        [AllowAnonymous]
        public ActionResult Index2(string ara,int? page)
        {
            var model = kitapTurleriDAL.GetAll(context).ToPagedList(page?? 1,3);
            if (ara!=null)
            {
                model = kitapTurleriDAL.GetAll(context, x => x.KitapTuru.Contains(ara)).ToPagedList(page ?? 1, 3);
            }   
            return View("Index",model); ;
        }
        //get
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Ekle() 
        {
            return View(new KitapTurleri());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderatör")]
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
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Duzenle(int id)
        {
            var model = kitapTurleriDAL.GetByID(context, id);
            if (model == null)
                return HttpNotFound();
            return View(model); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Duzenle(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)
            {
                kitapTurleriDAL.insertupdate(context, kitapTurleri);
                kitapTurleriDAL.save(context);
                return RedirectToAction("Index");
            }
            return View(kitapTurleri);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Sil(int? id)
        {
            kitapTurleriDAL.delete(context, k => k.ID == id);
            kitapTurleriDAL.save(context);
            return RedirectToAction("Index");
        }

    }
}