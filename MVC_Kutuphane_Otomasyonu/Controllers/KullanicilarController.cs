using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Mapping;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using MVC_Kutuphane_Otomasyonu_Entities.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{
    [Authorize]
 
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        KutuphaneContext context = new KutuphaneContext();
        KullanıcılarDAL kullanicilarDal = new KullanıcılarDAL();
        KullanıcıRolleriDAL kullaniciRolleriDal = new KullanıcıRolleriDAL();
        RollerDAL rollerDal = new RollerDAL();
        KullanıcıHareketleriDAL kullaniciHareketleriDal = new KullanıcıHareketleriDAL();

        public void KullaniciHareketleri(int kullaniciId, int islemYapanId,string aciklama)
        {
                var model=new KullanıcıHareketleri
                {
                KullanıcıID = kullaniciId,
                islemYapan = islemYapanId,
                Aciklama = aciklama,
                Tarih = DateTime.Now
                 };
            kullaniciHareketleriDal.insertupdate(context, model);
            kullaniciHareketleriDal.save(context);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model= kullanicilarDal.GetAll(context);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Ekle()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Ekle(Kullanicilar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            else
            {
                kullanicilarDal.insertupdate(context, entity);
                kullanicilarDal.save(context);


                int kullaniciId=context.Kullanicilar.Max(x=>x.ID);
                var userName = User.Identity.Name;
                var model = kullanicilarDal.GetByFilter(context, x => x.Email == userName);
                var islemYapan = model.ID;
                string aciklama = model.AdSoyad + " adlı kullanıcı yeni bir kulllanıcı eklendi.";
                KullaniciHareketleri(kullaniciId, islemYapan, aciklama);

                return RedirectToAction("Index2");
            }
        }
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Duzenle(int? id)
        {
            if(id==null)
            {
                return HttpNotFound("Id değeri girilmedi");
            }
            var model= kullanicilarDal.GetByID(context, id.Value);
            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Admin,Moderatör")]
        public ActionResult Duzenle(Kullanicilar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            else
            {
                // 1. ADIM: Veritabanındaki asıl kaydı ID'sine göre buluyoruz.
                // Not: Formdan gelen 'entity' nesnesi veritabanı ile bağsızdır, o yüzden onu doğrudan kullanmıyoruz.
                var model = context.Kullanicilar.Find(entity.ID);

                if (model != null)
                {
                    // 2. ADIM: Formdan gelen yeni bilgileri, veritabanındaki kaydın üzerine yazıyoruz.
                    model.AdSoyad = entity.AdSoyad;
                    model.KullanıcıAdı = entity.KullanıcıAdı;
                    model.Telefon = entity.Telefon;
                    model.Adres = entity.Adres;
                    model.Email = entity.Email;
                    model.Sifre = entity.Sifre;

                    // Kayıt tarihini değiştirmek istiyorsanız bu satırı açın:
                    model.KayitTarihi = entity.KayitTarihi;

                    // 3. ADIM: Değişiklikleri kaydediyoruz.
                    // Burada 'insertupdate' kullanmıyoruz, çünkü nesne zaten takipli (attached).
                    context.SaveChanges();
                }

                return RedirectToAction("Index2");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Sil(int? id)
        {
            kullanicilarDal.delete(context, k => k.ID == id);
            kullanicilarDal.save(context);
            return RedirectToAction("Index2");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index2()
        {
            var kullanicilar = kullanicilarDal.GetAll(context,tbl: "KullanıcıRolleri");
            var roller = rollerDal.GetAll(context); 
            return View(new KullaniciRolViewModel { Kullanicilar = kullanicilar,Roller=roller});            
        }

        public ActionResult KRolleri(int id)
        {
            var model = kullaniciRolleriDal.GetAll(context, x => x.KullanıcıID == id, "Roller");
           if(model!=null)
            {
               
                return View(model);
            }
            return HttpNotFound();
        }



        [AllowAnonymous]    
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanicilar entity)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            var model = kullanicilarDal.GetByFilter(context,x => x.Email==entity.Email && x.Sifre==entity.Sifre);
            if (model!=null)
            {
                FormsAuthentication.SetAuthCookie(entity.Email, false);
            
                int islemYapanId = model.ID;
                string aciklama = model.AdSoyad + " adlı kullanıcı giriş yaptı.";
                KullaniciHareketleri(islemYapanId, islemYapanId, aciklama);


                return RedirectToAction("Index2", "KitapTurleri");
            }
            ViewBag.error = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }
        [AllowAnonymous]
        public ActionResult KayitOl()
        {
          return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KayitOl(Kullanicilar entity,string sifreTekrar,bool kabul)
        {
            if (!ModelState.IsValid)//model doğrulama başarısız ise
            {
                return View(entity);
            }
            else///model doğrulama başarılı ise
            {
                if (entity.Sifre!=sifreTekrar)//şifreler uyuşmuyor
                {
                    ViewBag.sifreError = "Şifreler Uyuşmuyor!";
                    return View(entity);
                }

                else//şifreler uyuşuyor
                {
                    if (!kabul)
                    {
                        ViewBag.kabulError = "Lütfen Şartları Kabul Ettiğinizi Onaylayın!";
                        return View(entity);
                    }
                    else//şartlar kabul edildi
                    {
                        entity.KayitTarihi = DateTime.Now;
                        kullanicilarDal.insertupdate(context,entity);
                        kullanicilarDal.save(context);

                        int kullaniciId = context.Kullanicilar.Max(x => x.ID);
                       
                      
                        string aciklama = "  Yeni bir kulllanıcı oluşturuldu.";
                        KullaniciHareketleri(kullaniciId, kullaniciId, aciklama);


                        return RedirectToAction("Login");
                    }
                }

            }
        }
        [AllowAnonymous]
        public ActionResult SifremiUnuttum()
        {
           return View();   
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SifremiUnuttum(Kullanicilar entity)
        {
            var model = kullanicilarDal.GetByFilter(context, x => x.Email == entity.Email);

            if (model != null)
            {

                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 8);
                kullanicilarDal.save(context);


                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;


                client.UseDefaultCredentials = false;


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dyapma94@gmail.com", "Şifre sıfırlama");
                mail.To.Add(model.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body = "Merhaba " + model.AdSoyad + "<br/> Kullanıcı Adınız=" + model.KullanıcıAdı + "<br/> Şifreniz=" + model.Sifre;


                NetworkCredential net = new NetworkCredential("dyapma94@gmail.com", "uthe ugql eisq gapb");
                client.Credentials = net;


                client.Send(mail);
                return RedirectToAction("Login");
            }
            else if (model == null && entity.Email != null)
            {
                ViewBag.hata = "Böyle bir e-mail adresi bulunamadı.";
                return View(entity);
            }

            return View(entity);
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
      

    }
}