using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(RollerValidator))]
    public class Roller
    {
        public int ID { get; set; }
        public string Rol { get; set; }
       // public string Aciklama { get; set; }
       public List<KullanıcıRolleri> KullanıcıRolleri { get; set; } 

    }
}
