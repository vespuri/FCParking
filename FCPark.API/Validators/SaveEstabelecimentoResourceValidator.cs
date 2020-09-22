using FCPark.API.Resources;
using FluentValidation;

namespace FCPark.API.Validators
{
    public class SaveEstabelecimentoResourceValidator : AbstractValidator<SaveEstabelecimentoResource>
    {
        public SaveEstabelecimentoResourceValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250);
            RuleFor(a => a.CNPJ)
                .NotEmpty()
                .NotNull()
                .MaximumLength(14);
            RuleFor(a => a.Endereco)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250);
            RuleFor(a => a.Telefone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(25);
            RuleFor(a => a.QtdVagasCarros)
                .NotNull();
            RuleFor(a => a.QtdVagasCarros)
                .NotNull();

        }
    }
}
