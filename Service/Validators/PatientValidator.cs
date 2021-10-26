using Domain.Models;
using FluentValidation;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class PatientValidator : AbstractValidator<PatientViewModel>
    {
        public PatientValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.")
                .EmailAddress().WithMessage("Email Invalido");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Please enter the Price.")
                .NotNull().WithMessage("Please enter the Price.")
                .Must(ValidatorCPF).WithMessage("CPF Invalido");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Please enter a valid value.")
                .NotNull().WithMessage("Please enter a valid value.")
                .Matches(@"[0-9]+").WithMessage("Seu telefone deve conter numeros.")
                .MinimumLength(11).WithMessage("O tamanho minimo é de 11 caracteres");

        }

        private bool ValidatorCPF(string cpf)
        {
            cpf = RemoveNaoNumericos(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

    }
}