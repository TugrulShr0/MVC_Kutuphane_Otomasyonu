using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(DuyurularValidation))]
    public class Duyurular
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Duyuru { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }

    }
}
