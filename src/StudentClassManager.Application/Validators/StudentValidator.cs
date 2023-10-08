using FluentValidation;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.Validators
{
    public class StudentValidator : AbstractValidator<Dto.StudentDto>
    {
        public StudentValidator()
        {
            RuleFor(student => student.Nome).NotNull().WithMessage("O nome do aluno deve ser preenchido.");
            RuleFor(student => student.Usuario).NotNull().WithMessage("O usuário do aluno deve ser preenchido.");
            RuleFor(student => student.Senha)
                .MinimumLength(8)
                .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$")
                .WithMessage("A senha do aluno deve conter ao menos uma letra maiúscula, um número e um caractere especial e deve ter um tamanho mínimo de 8 caracteres.");
        }
    }
}
