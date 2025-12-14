using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class KitaplarValidator: AbstractValidator<Kitaplar>
    {
        public KitaplarValidator()
        {
            RuleFor(x => x.BarkodNo).NotEmpty().WithMessage("Barkod NO boş geçilemez.");
            RuleFor(x => x.KitapTürüId).NotEmpty().WithMessage("Kitap Türü Alanı boş geçilemez.");
            RuleFor(x => x.KitapAdı).NotEmpty().WithMessage("Kitap Adı boş geçilemez.");
            RuleFor(x => x.Yazar).NotEmpty().WithMessage("Yazar boş geçilemez.");
            RuleFor(x => x.Yayinevi).NotEmpty().WithMessage("Yayınevi boş geçilemez.");
            RuleFor(x => x.SayfaSayisi).GreaterThan(0).WithMessage("Sayfa sayısı 0'dan büyük olmalıdır.");
           
        }
    }
}
