using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class IletisimValidator :AbstractValidator<İletisim>
    {
        public IletisimValidator()
        {
            RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad Soyad boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Mesaj).NotEmpty().WithMessage("Mesaj boş geçilemez.");
            RuleFor(x => x.Aciklama).NotEmpty().WithMessage("Açıklama boş geçilemez.");
        }

    }
}
