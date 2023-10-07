using FluentValidation;

namespace StudentClassManager.Application.Validators
{
    public class ClassValidator : AbstractValidator<Dto.Class>
    {
        public ClassValidator() 
        {
            RuleFor(@class => @class.Turma).NotNull().WithMessage("O nome da turma deve ser preenchido.");
            RuleFor(@class => @class.Ano)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Não é possível cadastrar turmas para anos anteriores.");
        }
    }
}
