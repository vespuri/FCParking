using FCPark.API.Resources;
using FluentValidation;

namespace FCPark.API.Validators
{
    public class SaveClienteResourceValidator : AbstractValidator<SaveClienteResource>
    {
        public SaveClienteResourceValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250);
         
            RuleFor(a => a.Endereco)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250);

            RuleFor(a => a.Telefone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(25);
            
        }
    }
}

