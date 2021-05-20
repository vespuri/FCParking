using FCPark.API.Resources;
using FluentValidation;


namespace FCPark.API.Validators
{
    public class SaveMovimentacaoVeiculoResourceValidator : AbstractValidator<SaveMovimentacaoVeiculoResource>
    {
        public SaveMovimentacaoVeiculoResourceValidator()
        {
            RuleFor(a => a.VeiculoId)
                .NotNull();
            RuleFor(a => a.EstabelecimentoId)
                .NotNull();
            RuleFor(a => a.ClienteId)
                .NotNull();

        }
    }
}