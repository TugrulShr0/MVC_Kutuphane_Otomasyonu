using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(KullanıcılarValidator))]
    public class Kullanicilar
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string KullanıcıAdı { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public DateTime KayitTarihi { get; set; } 
        
        public List<KullanıcıHareketleri> KullanıcıHareketleri { get; set; }

        public List<KullanıcıRolleri> KullanıcıRolleri { get; set; }

    }
}
