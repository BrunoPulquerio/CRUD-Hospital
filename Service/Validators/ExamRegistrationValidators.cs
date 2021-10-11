using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class ExamRegistrationValidator : AbstractValidator<ExamRegistration>
    {
        public ExamRegistrationValidator()
        {
            RuleFor(c => c.Name)
           .MaximumLength(100).WithMessage("O tamanho maximo é de 100 caracteres");

            RuleFor(c => c.Note)
           .MaximumLength(1000).WithMessage("O tamanho maximo é de 1000 caracteres");

            RuleFor(c => c.TypeOfExamId)
                .NotNull().WithMessage("Please enter the email.");
        }
    }
}
