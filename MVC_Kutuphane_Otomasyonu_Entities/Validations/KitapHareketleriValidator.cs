using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class KitapHareketleriValidator: AbstractValidator<KitapHareketleri>
    {
        public KitapHareketleriValidator()
        {
            RuleFor(x => x.YapılanIslem).MaximumLength(100).WithMessage("Yapılan işlem alanı en fazla 100 karakter olmalıdır.");

        }
    }
}
