using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class EmanetKitaplarValidator: AbstractValidator<EmanetKitaplar>
    {
        public EmanetKitaplarValidator()
        {
            RuleFor(x => x.UyeID).NotEmpty().WithMessage("Üye ID boş geçilemez.");
            RuleFor(x => x.KitapID).NotEmpty().WithMessage("Kitap ID boş geçilemez.");
            RuleFor(x => x.EmanetTarihi).NotEmpty().WithMessage("Emanet tarihi boş geçilemez.");
            //RuleFor(x => x.IadeTarihi).NotEmpty().WithMessage("İade tarihi boş geçilemez.");
        }
    }
}
