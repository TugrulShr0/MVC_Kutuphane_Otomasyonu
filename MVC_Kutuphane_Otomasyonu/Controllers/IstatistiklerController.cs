using ClosedXML.Excel;
using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{
    public class IstatistiklerController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullanıcıHareketleriDAL kullaniciHareketleriDAL = new KullanıcıHareketleriDAL();
        KullanıcılarDAL kullaniciDAL = new KullanıcılarDAL();
        UyelerDAL uyelerDAL = new UyelerDAL();
        EmanetKitaplarDAL emanetKitaplarDAL = new EmanetKitaplarDAL();
        // GET: Istatistikler
        public ActionResult Index()
        {
            //uyeler
            uyelerDAL.UyeKitapIslemleri();
            ViewBag.EnCokUye = uyelerDAL.EnCokUye;
            ViewBag.EnAzUye = uyelerDAL.EnAzUye;
            ViewBag.EnCokSayi = uyelerDAL.EnCokSayi;
            ViewBag.EnAzSayi = uyelerDAL.EnAzSayi;

            ViewBag.UyeKitapModel = uyelerDAL.UyeKitapModel;

            //Kullanıcı Sayısı
            var KullaniciSayisiModel = kullaniciDAL.GetAll(context);
            ViewBag.Count = KullaniciSayisiModel.Count();
            //En Çok Giriş Yapan Kullanıcı
            var model = kullaniciHareketleriDAL.KullaniciGirisSayilari();
            ViewBag.KullaniciAdi = model.KullaniciAdi;
            ViewBag.GirisSayisi = model.GirisSayisi;
            //Kullanıcı Hareketleri Gözlemleme
            kullaniciHareketleriDAL.KullaniciHareketleriGozlemleme();

            ViewBag.AylikVeriler = kullaniciHareketleriDAL.AylikVeriler;
            ViewBag.ToplamKHGSayisi = kullaniciHareketleriDAL.ToplamKHGSayisi;
            ViewBag.AltiAyToplamKHGSayisi = kullaniciHareketleriDAL.AltiAyToplamKHGSayisi;


            return View();
        }
        public ActionResult ExceleAktar()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Emanet Kitaplar");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Üye";
                worksheet.Cell(1, 3).Value = "Kitap Adı";
                worksheet.Cell(1, 4).Value = "Kitap Sayısı";
                worksheet.Cell(1, 5).Value = "Kitap Aldığı Tarih";


                var model = emanetKitaplarDAL.GetAll(context, x => x.IadeTarihi == null, "Uyeler", "kitaplar");
                int row = 2;
                foreach (var item in model)
                {

                    worksheet.Cell(row, 1).Value = item.ID;
                    worksheet.Cell(row, 2).Value = item.Uyeler.AdSoyad;
                    worksheet.Cell(row, 3).Value = item.kitaplar.KitapAdı;
                    worksheet.Cell(row, 4).Value = item.KitapSayisi;
                    worksheet.Cell(row, 5).Value = item.EmanetTarihi;
                    row++;
                }
                using (var stream = new System.IO.MemoryStream())//excel dosyasını bellekte tutmak için
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;
                   
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmanetKitaplarSeri.xlsx");
                }
            }

           
        }
    }
}