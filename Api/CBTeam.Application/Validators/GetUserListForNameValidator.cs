using CBTeam.Application.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Application.Validators
{
    public class GetUserListForNameValidator : AbstractValidator<GetUserListForNameRequest>
    {
        public GetUserListForNameValidator()
        {
            RuleFor(u => u.name)
                .Must(BeNonNumeric)
                .WithMessage("El valor ingresado no puede ser numérico");

            RuleFor(u => u.name)
                .NotEmpty()
                .WithMessage("Debe ingresar un nombre");

            RuleFor(u => u.name)
                .Length(3, 10)
                .WithMessage("Debe ingresar un nombre que contenga entre 3 y 10 caracteres");
        }

        private bool BeNonNumeric(string value)
        {
            return !double.TryParse(value, out _);
        }
    }
}
