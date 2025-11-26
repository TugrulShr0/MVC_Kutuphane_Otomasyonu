using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(HakkimizdaValidator))]
    public class Hakkimizda
    {
        public int ID { get; set; }
        public string Icerik { get; set; }
        public string Aciklama { get; set; }
    }
}
