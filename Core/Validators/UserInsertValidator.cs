using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class UserInsertValidator : AbstractValidator<UserInsertDto>
    {
        public UserInsertValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe contener entre 2 y 20 caracteres.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("El email es obligatorio.");
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
