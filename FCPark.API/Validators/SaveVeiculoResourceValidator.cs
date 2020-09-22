using FCPark.API.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCPark.API.Validators
{
    public class SaveVeiculoResourceValidator : AbstractValidator<SaveVeiculoResource>
    {
        public SaveVeiculoResourceValidator()
        {
            RuleFor(a => a.Marca)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(a => a.Modelo)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(a => a.Cor)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15);
            RuleFor(a => a.Placa)
                .NotEmpty()
                .NotNull()
                .MaximumLength(7);
            RuleFor(a => a.Tipo)
                .NotEmpty()
                .NotNull()
                .MaximumLength(25);
        }
    }
}
