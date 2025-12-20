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
    [AllowAnonymous]

    public class HomeController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        HakkimizdaDAL hakkimizdaDAL = new HakkimizdaDAL();
        IletisimDAL iletisimDAL = new IletisimDAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = hakkimizdaDAL.GetAll(context);

            return View(model);
        }

        public ActionResult Contact()
        {
       

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(İletisim model)
        {
            if (ModelState.IsValid)
            {
                model.Tarih = DateTime.Now;
                iletisimDAL.insertupdate(context, model);
                iletisimDAL.save(context);  
                TempData["Message"] = "Mesajınız başarıyla gönderilmiştir.";
                return RedirectToAction("Contact");
            }

            return View(model);
        }
        public ActionResult AdminIndex()
        {
           

            return View();
        }
    }
}