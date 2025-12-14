using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class KitapTurleriValidator: AbstractValidator<KitapTurleri>
    {
        public KitapTurleriValidator()
        {
            RuleFor(x => x.KitapTuru).NotEmpty().WithMessage("Tür Adı boş geçilemez.");
            RuleFor(x => x.KitapTuru).MinimumLength(5).WithMessage("Tür Adı en az 5 karakter olmalıdır.");
            RuleFor(x => x.KitapTuru).MaximumLength(150).WithMessage("Tür Adı en fazla 150 karakter olmalıdır.");
        }
    }
}
