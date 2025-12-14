using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(KitaplarValidator))]
    public class Kitaplar
    {
        public int ID { get; set; }
        public string BarkodNo { get; set; }
        public int KitapTürüId { get; set; }
        public string KitapAdı { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public int SayfaSayisi { get; set; }   
        public int StokAdedi { get; set; }
        public string Aciklama { get; set; }   
        public DateTime EklenmeTarihi { get; set; }= DateTime.Now;
        public DateTime GuncellenmeTarihi { get; set; }= DateTime.Now;
        public bool SilindiMi { get; set; }=false;
        public KitapTurleri KitapTurleri { get; set; } // Her kitabın bir türü vardır

        public List<EmanetKitaplar> EmanetKitaplar { get; set; } // Bir kitabın birden fazla emanet kaydı olabilir
        public List<KitapHareketleri> KitapHareketleri { get; set; } // Bir kitabın birden fazla hareket kaydı olabilir
        public List<KitapKayitHareketleri> KitapKayitHareketleri { get; set; } // Bir kitabın birden fazla kayıt hareketi olabilir
    }
}
