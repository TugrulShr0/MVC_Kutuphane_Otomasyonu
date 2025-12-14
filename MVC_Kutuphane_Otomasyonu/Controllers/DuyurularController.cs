using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{
    public class DuyurularController : Controller
    {
        // GET: Duyurular
        KutuphaneContext context = new KutuphaneContext();
        DuyurularDAL duyurularDAL = new DuyurularDAL();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DuyuruList()
        {
            var model = duyurularDAL.GetAll(context);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DuyuruEkle(Duyurular entity)
        {
            // ID > 0 ise UPDATE yapılıyor demektir. ID validasyonunu temizle.
            if (entity.ID > 0)
            {
                ModelState["ID"]?.Errors.Clear();
            }

            if (ModelState.IsValid)
            {
                if (entity.ID > 0)
                {
                    // ----------------------------------------------------
                    // !!! GÜNCELLEME İŞLEMİ DÜZELTİLDİ !!!
                    // ----------------------------------------------------

                    var model = context.Duyurular.Find(entity.ID);

                    if (model != null)
                    {
                        // Formdan gelen yeni değerleri, veritabanından çekilen kaydın üzerine yazıyoruz.
                        model.Baslik = entity.Baslik;
                        model.Duyuru = entity.Duyuru;
                        model.Aciklama = entity.Aciklama;
                        model.Tarih = entity.Tarih;

                        // Bu nesne zaten Context tarafından takip edildiği için DAL'daki update metoduna
                        // gerek yok, direkt SaveChanges diyebiliriz.
                        context.SaveChanges();
                    }
                    return Json(new { success = true, message = entity.ID + " Nolu Duyuru Başarıyla Güncellendi." });
                }
                else
                {
                    // ----------------------------------------------------
                    // YENİ KAYIT İŞLEMİ
                    // ----------------------------------------------------
                    duyurularDAL.insertupdate(context, entity);
                    duyurularDAL.save(context);
                    return Json(new { success = true, message = "Yeni Duyuru Başarıyla Eklendi." });
                }
            }

            // Hata varsa geri döndür
            var errors = ModelState.ToDictionary(
                x => x.Key,
                x => x.Value.Errors.Select(a => a.ErrorMessage).ToArray()
            );
            return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
        }         
        
        public JsonResult DuyuruGetir(int? id)
        {
          var model =  duyurularDAL.GetByFilter(context, x=>x.ID==id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DuyuruSil(int? id)
        {
            duyurularDAL.delete(context, x => x.ID == id);
            duyurularDAL.save(context);
            return Json(new { success = true });
        }
        [HttpPost]
        public JsonResult SeciliDuyuruSil(List<int> selectedIds)
        {
            if (selectedIds!=null)
            {
                foreach (var id in selectedIds)
                {
                    duyurularDAL.delete(context, x => x.ID == id);
                    duyurularDAL.save(context);
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });   
        }
    }
}