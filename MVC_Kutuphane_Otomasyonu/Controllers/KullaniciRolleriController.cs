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
    [Authorize(Roles = "Admin")]
    //[AllowAnonymous]
    public class KullaniciRolleriController : Controller
    {
       
        // GET: KullaniciRolleri
        KutuphaneContext context=new KutuphaneContext();
        KullanıcıRolleriDAL kullaniciRolleriDAL=new KullanıcıRolleriDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ekle(int? id) 
        {
            if (id==null)
            {
                return HttpNotFound("Kullanıcı Id değeri girilmedi");
            }
            var model = kullaniciRolleriDAL.GetByFilter(context, x => x.KullanıcıID == id, "Kullanicilar");

            ViewBag.KullaniciId = id;
            ViewBag.kullaniciAdı = model.Kullanicilar.KullanıcıAdı;
            ViewBag.liste=new SelectList(context.Roller,"ID","Rol");
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(KullanıcıRolleri entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.Roller, "ID", "Rol");
                var model = kullaniciRolleriDAL.GetByFilter(context, x => x.KullanıcıID == entity.KullanıcıID, "Kullanicilar");
                ViewBag.KullaniciId = entity.ID;
                ViewBag.KullaniciId = entity.KullanıcıID;
                return View(entity);
            }
            entity.ID = 0;
            kullaniciRolleriDAL.insertupdate(context, entity);
            kullaniciRolleriDAL.save(context);
            return RedirectToAction("Index2", "Kullanicilar");
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Kullanıcı Id değeri girilmedi");
            }
            var model = kullaniciRolleriDAL.GetByFilter(context, x => x.ID == id, "Kullanicilar");
            ViewBag.kullaniciAdı = model.Kullanicilar.KullanıcıAdı;
            ViewBag.liste = new SelectList(context.Roller, "ID", "Rol");

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(KullanıcıRolleri entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.Roller, "ID", "Rol");
                // Hata durumunda model null dönmesin diye tekrar çekiyoruz
                var model = kullaniciRolleriDAL.GetByFilter(context, x => x.ID == entity.ID, "Kullanicilar");
                if (model != null && model.Kullanicilar != null)
                {
                    ViewBag.KullaniciAdı = model.Kullanicilar.KullanıcıAdı;
                }
                return View(entity);
            }

            // --- GÜNCELLEME MANTIĞI BURADA DEĞİŞTİ ---

            // 1. Veritabanındaki asıl kaydı buluyoruz
            var guncellenecekKayit = context.KullanıcıRolleri.Find(entity.ID);

            if (guncellenecekKayit != null)
            {
                // 2. Sadece değişmesi gereken alanları güncelliyoruz
                // Kullanıcı değişmeyecek, sadece Rol değişecek varsayıyorum
                guncellenecekKayit.RolId = entity.RolId;

                // Eğer kullanıcının kendisini de değiştirebiliyorsanız:
                // guncellenecekKayit.KullanıcıID = entity.KullanıcıID;

                // 3. Kaydediyoruz
                context.SaveChanges();
            }
            // ------------------------------------------

            return RedirectToAction("Index2", "Kullanicilar");
        }
        public ActionResult Sil(int? id)
        {
            kullaniciRolleriDAL.delete(context,x=>x.ID==id);
            kullaniciRolleriDAL.save(context);
            return RedirectToAction("Index2", "Kullanicilar");
        }
    }
}