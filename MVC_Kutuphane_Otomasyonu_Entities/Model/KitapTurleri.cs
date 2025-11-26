using FluentValidation.Attributes;
using MVC_Kutuphane_Otomasyonu_Entities.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model
{
    [Validator(typeof(KitapTurleriValidator))]
    public class KitapTurleri
    {
     
        public int ID { get; set; }

        [Required(ErrorMessage = "Kitap türü boş olamaz!")]
        [MaxLength(50)]
        public string KitapTuru { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Aciklama { get; set; } = "";
        

        public List<Kitaplar> Kitaplar { get; set; } = new List<Kitaplar>();   // Bir türün birden fazla kitabı olabilir
    }
}
