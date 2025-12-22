using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Mapping;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DocumentFormat.OpenXml.Wordprocessing;
namespace MVC_Kutuphane_Otomasyonu.Controllers
{
    [Authorize]
    public class EmanetKitaplarController : Controller
    {
        // GET: EmanetKitaplar
        KutuphaneContext context = new KutuphaneContext();
        EmanetKitaplarDAL EmanetKitaplarDAL = new EmanetKitaplarDAL();
        KitaplarDAL kitaplarDAL = new KitaplarDAL();
        KitapHareketleriDAL kitapHareketleriDAL = new KitapHareketleriDAL();
        public ActionResult Index()
        {
            // Eğer giriş yapan kişi Admin veya Moderatör ise her şeyi görsün
            if (User.IsInRole("Admin") || User.IsInRole("Moderatör"))
            {
                var model = EmanetKitaplarDAL.GetAll(context, null, "kitaplar", "Uyeler");
                return View(model);
            }
            else
            {
                // Eğer normal kullanıcı ise sadece KENDİ emanetlerini görsün
                var email = User.Identity.Name;
                var model = EmanetKitaplarDAL.GetAll(context, x => x.Uyeler.Email == email, "kitaplar", "Uyeler");
                return View(model);
            }
        }
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Yazdir()
        {
            var model = EmanetKitaplarDAL.GetAll(context, null, "kitaplar", "Uyeler");
            return new Rotativa.ActionAsPdf("EmanetListesi", model)
            {

                FileName = "EmanetKitapListesi.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult EmanetListesi()
        {
            var model = EmanetKitaplarDAL.GetAll(context, null, "kitaplar", "Uyeler");
            return View(model);
        }

        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult EmanetKitapVer()
        {
            ViewBag.Uyeliste = new SelectList(context.Uyeler, "ID", "AdSoyad");
            ViewBag.Kitapliste = new SelectList(context.Kitaplar, "ID", "KitapAdı");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult EmanetKitapVer(EmanetKitaplar entity)
        {
            if (ModelState.IsValid)
            {
                var email=User.Identity.Name;
                var modelKullanici=context.Kullanicilar.FirstOrDefault(x=>x.Email==email);
                EmanetKitaplarDAL.insertupdate(context, entity);
                var kitapHareket = new KitapHareketleri 
                { 
                    KullanıcıID=modelKullanici.ID,
                    KitapID=entity.KitapID,
                    UyeID=entity.UyeID,
                    YapılanIslem="Emanet Kitap İşlemi",
                    Tarih=DateTime.Now

                };
                kitapHareketleriDAL.insertupdate(context, kitapHareket);


                //var model = kitaplarDAL.GetByFilter(context, x => x.ID == entity.KitapID);
                //model.StokAdedi=model.StokAdedi-entity.KitapSayisi;         
                entity.ID = 0;
                EmanetKitaplarDAL.save(context); 
                return RedirectToAction("Index");
            }
 
            ViewBag.Uyeliste = new SelectList(context.Uyeler, "ID", "AdSoyad");
            ViewBag.Kitapliste = new SelectList(context.Kitaplar, "ID", "KitapAdı");
            return View("Index");
        }
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.Uyeliste = new SelectList(context.Uyeler, "ID", "AdSoyad");
            ViewBag.Kitapliste = new SelectList(context.Kitaplar, "ID", "KitapAdı");
            var model= EmanetKitaplarDAL.GetByFilter(context, x=>x.ID==id,"Uyeler","kitaplar");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Duzenle(EmanetKitaplar entity)
        {
            if (ModelState.IsValid)
            {
                // Entity'nin veritabanındaki varlığını EF'ye bildirin
                var entry = context.Entry(entity);

                if (entity.ID > 0)
                {
                    // Eğer ID varsa, bu kaydın güncelleneceğini (Modified) açıkça söyleyin
                    entry.State = EntityState.Modified;
                }
                else
                {
                    // ID yoksa veya 0 ise yeni kayıt olarak ekle
                    entry.State = EntityState.Added;
                }

                context.SaveChanges(); // Veya EmanetKitaplarDAL.save(context);
                return RedirectToAction("Index");
            }

            ViewBag.Uyeliste = new SelectList(context.Uyeler, "ID", "AdSoyad", entity.UyeID);
            ViewBag.Kitapliste = new SelectList(context.Kitaplar, "ID", "KitapAdı", entity.KitapID);
            return View(entity);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
        
            EmanetKitaplarDAL.delete(context,x=>x.ID==id);
            EmanetKitaplarDAL.save(context);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult TeslimAl(int? id)
        {
            var model=EmanetKitaplarDAL.GetByFilter(context,x=>x.ID==id);
            model.IadeTarihi=DateTime.Now;

            var kitaplar=kitaplarDAL.GetByFilter(context, x=>x.ID==model.KitapID);
            kitaplar.StokAdedi=kitaplar.StokAdedi+model.KitapSayisi;
            EmanetKitaplarDAL.save(context);
            return RedirectToAction("Index");
        }
    }
}
