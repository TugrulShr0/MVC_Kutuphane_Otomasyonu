using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class KullanıcılarValidator : AbstractValidator<Kullanicilar>
    {
      public KullanıcılarValidator()
        {
            RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad Soyad boş geçilemez.");
            RuleFor(x => x.KullanıcıAdı).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez.");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre boş geçilemez.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres boş geçilemez.");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon boş geçilemez.");
        }
    }
}
