using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class TypeOfExamValidator : AbstractValidator<TypeOfExam>
    {
        public TypeOfExamValidator()
        {
                 RuleFor(c => c.Name)
                .MaximumLength(100).WithMessage("O tamanho maximo é de 100 caracteres");

                 RuleFor(c => c.Description)
                .MaximumLength(256).WithMessage("O tamanho maximo é de 256 caracteres");

        }
    }
}