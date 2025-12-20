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
    public class UyelerDAL: GenericRepository<KutuphaneContext, Uyeler>
    {
        KutuphaneContext context = new KutuphaneContext();

        public string EnCokUye;
        public string EnAzUye;
        public int EnCokSayi;
        public int EnAzSayi;

        public object UyeKitapModel;
        public object UyeKitapIslemleri()
        {
            EnCokUye = context.Uyeler.OrderByDescending(x => x.OkuKitapSayisi).FirstOrDefault().AdSoyad;
            EnAzUye = context.Uyeler.OrderBy(x => x.OkuKitapSayisi).FirstOrDefault().AdSoyad;

            EnCokSayi = context.Uyeler.OrderByDescending(x => x.OkuKitapSayisi).FirstOrDefault().OkuKitapSayisi;

            EnAzSayi = context.Uyeler.Min(x => x.OkuKitapSayisi);

            double ToplamKitap = context.Uyeler.Sum(x => x.OkuKitapSayisi);
            UyeKitapModel=context.Uyeler.OrderByDescending(x => x.OkuKitapSayisi).Take(3).Select(y => new
                {
                    y.AdSoyad,
                    y.OkuKitapSayisi,
                    Yuzde = (y.OkuKitapSayisi*100)/ ToplamKitap
            }).ToList();



            return UyeKitapModel;
        }









    }
}
