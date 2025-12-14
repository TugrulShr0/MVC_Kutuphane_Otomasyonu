using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class UyelerValidator: AbstractValidator<Uyeler>
    {
        public UyelerValidator()
        {
            RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad Soyad boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres boş geçilemez.");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon boş geçilemez.");
            RuleFor(x => x.KayitTarihi).NotEmpty().WithMessage("Kayıt Tarihi boş geçilemez.");
        }
    }
}
