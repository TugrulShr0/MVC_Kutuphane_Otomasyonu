using FluentValidation;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Validations
{
    public class RollerValidator: AbstractValidator<Roller>
    {
        public RollerValidator()
        {
            RuleFor(x => x.Rol).NotEmpty().WithMessage("Rol Adı boş geçilemez.");
            RuleFor(x => x.Rol).MaximumLength(100).WithMessage("Rol Adı en fazla 100 karakter olmalıdır.");
        }
    }
}
