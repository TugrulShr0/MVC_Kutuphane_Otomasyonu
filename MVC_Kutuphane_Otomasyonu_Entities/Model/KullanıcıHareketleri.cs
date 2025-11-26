using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(KullanıcıHareketleriValidator))]
    public class KullanıcıHareketleri
    {
        public int ID { get; set; }
      //  public int AdminID { get; set; }
        public int KullanıcıID { get; set; }
       // public string YapılanIslem { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
    }
}
