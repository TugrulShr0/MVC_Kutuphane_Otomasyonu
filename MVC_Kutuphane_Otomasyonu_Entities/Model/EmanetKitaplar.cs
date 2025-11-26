using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(EmanetKitaplarValidator))]
    public class EmanetKitaplar
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public int KitapID { get; set; }
        public int KitapSayisi { get; set; }    
        public DateTime EmanetTarihi { get; set; }
        public DateTime IadeTarihi { get; set; }

        public Kitaplar kitaplar { get; set; }

        public Uyeler Uyeler { get; set; } 
        

    }
}
