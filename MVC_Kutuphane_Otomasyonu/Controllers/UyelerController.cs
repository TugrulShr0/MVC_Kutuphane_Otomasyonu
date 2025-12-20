using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UyelerController : Controller
    {
        // GET: Uyeler
        KutuphaneContext context = new KutuphaneContext();
        UyelerDAL uyelerDAL = new UyelerDAL();
        public ActionResult Index()
        {
            var model = uyelerDAL.GetAll(context);
            return View(model);
        }
        public ActionResult Ekle()
        {
            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Uyeler entity,HttpPostedFileBase Resim)
        {
          if (ModelState.IsValid)
          {
                if (Resim!=null && Resim.ContentLength>0)
                {
                    var image= Path.GetFileName(Resim.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), image);
                    if (System.IO.File.Exists(path)==false)
                    {
                        Resim.SaveAs(path);
                    }
                    entity.Resim = "/images/" + image;
                }
                uyelerDAL.insertupdate(context, entity);
                uyelerDAL.save(context);
                return RedirectToAction("Index");
          }
            return View(entity);
        }
        public ActionResult Duzenle(int id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var model= uyelerDAL.GetByFilter(context, x => x.ID == id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Uyeler entity, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                // 1. Veritabanındaki asıl kaydı çekiyoruz (Context bunu artık takip ediyor)
                var model = uyelerDAL.GetByFilter(context, x => x.ID == entity.ID);

                // Eğer kayıt bulunamazsa hata dönelim
                if (model == null) return HttpNotFound();

                // 2. Formdan gelen güncel bilgileri, Modele aktarıyoruz.
                // DİKKAT: Buradaki isimler View dosyanızdaki isimlerle aynı olmalı!
                model.AdSoyad = entity.AdSoyad;
                model.Telefon = entity.Telefon;
                model.Adres = entity.Adres;
                model.Email = entity.Email;
                model.OkuKitapSayisi = entity.OkuKitapSayisi;
                model.KayitTarihi = entity.KayitTarihi; // Tarihi de güncellemek isterseniz

                // 3. Resim İşlemleri
                if (Resim != null && Resim.ContentLength > 0)
                {
                    var image = Path.GetFileName(Resim.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), image);
                    if (System.IO.File.Exists(path) == false)
                    {
                        Resim.SaveAs(path);
                    }
                    model.Resim = "/images/" + image;
                }

                // 4. Kaydetme İşlemi
                // ÖNEMLİ: 'insertupdate' metodunu kaldırdık. 
                // Çünkü 'model' zaten veritabanından çekildiği için canlı (tracked) bir nesne.
                // Sadece Save demek, değişiklikleri algılayıp Update sorgusu atması için yeterlidir.
                uyelerDAL.save(context);

                return RedirectToAction("Index");
            }
            return View(entity);
        }
        public ActionResult Sil(int id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            uyelerDAL.delete(context, x => x.ID == id);
            uyelerDAL.save(context);
            return RedirectToAction("Index");
        }
    }
}