using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(KullaniciRolleriValidator))]
    public class KullanıcıRolleri
    {
        public int ID { get; set; }
        public int KullanıcıID { get; set; }
        public int RolId { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
       
        public Roller Roller { get; set; }
    }
}
