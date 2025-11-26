using FluentValidation;
using FluentValidation.Validators;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class DuyurularValidation : AbstractValidator<Duyurular>
    {
        public DuyurularValidation() 
        { 
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("Duyuru başlığı boş geçilemez.");
            RuleFor(x => x.Duyuru).NotEmpty().WithMessage("Duyuru içeriği boş geçilemez.");
            RuleFor(x => x.Baslik).Length(5,200).WithMessage("Başlık alanı 5-200 karakter arasında olmalıdır");
            RuleFor(x => x.Duyuru).MaximumLength(500).WithMessage("Duyuru alanı en fazla 500 karakter  olmalıdır");
            RuleFor(x=>x.Tarih).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");

        }
    }
}
