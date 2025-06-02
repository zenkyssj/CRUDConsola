using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe contener entre 2 y 20 caracteres.");        

            RuleFor(x => x.Email).NotEmpty().WithMessage("El email es obligatorio.");
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es obligatoria");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("La contraseña debe contener minimo 8 caracteres");

            RuleFor(x => x.Age).NotEmpty().WithMessage("La edad es obligatoria");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("La edad debe ser mayor a 0.");
        }
    }
}
