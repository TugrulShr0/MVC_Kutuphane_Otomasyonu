using MVC_Kutuphane_Otomasyonu_Entities.Model;
using MVC_Kutuphane_Otomasyonu_Entities.Model.Context;
using MVC_Kutuphane_Otomasyonu_Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.DAL
{
    public class KullanıcıHareketleriDAL: GenericRepository<KutuphaneContext, KullanıcıHareketleri>
    {
        KutuphaneContext context = new KutuphaneContext();

        public object AylikVeriler;
        public object ToplamKHGSayisi;
        public object AltiAyToplamKHGSayisi;

        public (string KullaniciAdi,int GirisSayisi) KullaniciGirisSayilari()
        {
            var result = context.Set<KullanıcıHareketleri>().GroupBy(x=> new {x.KullanıcıID,x.Kullanicilar.KullanıcıAdı})
                .Select(y=> new 
                {
                    KullaniciAdi= y.Key.KullanıcıAdı,
                    GirisSayisi = y.Count()
                }).OrderByDescending(x=> x.GirisSayisi).FirstOrDefault();
            if (result != null)
            {
                return (result.KullaniciAdi, result.GirisSayisi);
            }
            return(null,0); 
        }
        public object KullaniciHareketleriGozlemleme()
        {
            DateTime altiAyOnce= DateTime.Now.AddMonths(-6);
            AylikVeriler= context.KullanıcıHareketleri
                .Where(x => x.Tarih >= altiAyOnce)
                .GroupBy(x => new { Ay = x.Tarih.Month, Yil = x.Tarih.Year })
                .Select(g => new
                {
                    Ay = g.Key.Ay,
                    Yil = g.Key.Yil,
                    HareketSay = g.Count()
                })
                .OrderBy(x => x.Yil).ThenBy(x => x.Ay)
                .ToList();
            ToplamKHGSayisi= context.KullanıcıHareketleri.Count();
            AltiAyToplamKHGSayisi = context.KullanıcıHareketleri
                .Count(x => x.Tarih >= altiAyOnce);
         
            return AylikVeriler;
        }

    }
}
