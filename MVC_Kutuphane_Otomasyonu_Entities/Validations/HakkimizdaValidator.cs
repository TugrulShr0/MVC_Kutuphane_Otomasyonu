using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class HakkimizdaValidator: AbstractValidator<Hakkimizda>
    {
        public HakkimizdaValidator()
        {
            RuleFor(x => x.Icerik).NotEmpty().WithMessage("İçerik boş geçilemez.");
            
            RuleFor(x => x.Icerik).MinimumLength(10).WithMessage("İçerik alanı en az 10 karakter olmalıdır");
        }
    }
}
