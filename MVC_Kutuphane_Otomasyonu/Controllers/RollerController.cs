using MVC_Kutuphane_Otomasyonu_Entities.DAL;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using MVC_Kutuphane_Otomasyonu_Entities.Model; // Bu satır eksik veya yanlış olabilir
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Kutuphane_Otomasyonu.Controllers
{
     [Authorize(Roles = "Admin")]
   //[AllowAnonymous]
    public class RollerController : Controller
    {
        // GET: Roller
        KutuphaneContext context = new KutuphaneContext();
        RollerDAL rollerDAL = new RollerDAL();
        public ActionResult Index()
        {
            var model = rollerDAL.GetAll(context);
            return View(model);
        }
        public ActionResult Ekle()
        { 
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Roller entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            rollerDAL.insertupdate(context,entity);
            rollerDAL.save(context);
            return RedirectToAction("Index");

        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Id değeri girilmedi");
            }
            var model = rollerDAL.GetByFilter(context, x=>x.ID==id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Roller entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            // --- GÜNCELLEME ÇÖZÜMÜ ---

            // 1. Veritabanındaki gerçek kaydı buluyoruz
            var guncellenecekRol = context.Roller.Find(entity.ID);

            if (guncellenecekRol != null)
            {
                // 2. Formdan gelen yeni adı, eski kaydın üzerine yazıyoruz
                // NOT: Veritabanınızdaki sütun adı 'Rol' ise böyle kalacak, 'RolAdi' ise değiştirin.
                guncellenecekRol.Rol = entity.Rol;

                // 3. Değişiklikleri kaydediyoruz
                context.SaveChanges();
            }
            // -------------------------

            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
   
            rollerDAL.delete(context, x=>x.ID==id);
            rollerDAL.save(context);
            return RedirectToAction("Index");
        }
    }
}