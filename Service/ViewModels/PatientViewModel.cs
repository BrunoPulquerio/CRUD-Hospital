using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Paciente")]
        [Required(ErrorMessage = "Preencha o campo Nome do Paciente")]
        [MinLength(10, ErrorMessage = "O Campo precisa ter mais que 10 caracteres")]
        [MaxLength(100, ErrorMessage = "O Campo precisa ter menos que 100 caracteres")]
        public string Name { get; set; }

        [Display(Name = "CPF do Paciente")]
        [Required(ErrorMessage = "Preencha o campo CPF do Paciente")]
        [MaxLength(11, ErrorMessage = "O Campo precisa ter menos que 11 caracteres")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Preencha o campo Data de Nascimento")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Selecionar o campo Genero")]
        public string Gender { get; set; }

        [Display(Name = "Numero de Telefone")]
        [Required(ErrorMessage = "Selecionar o campo Numero de Telefone")]
        [MaxLength(11, ErrorMessage = "O Campo precisa ter menos que 11 caracteres")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Selecionar o campo Numero de Email")]
        [MaxLength(150, ErrorMessage = "O Campo precisa ter menos que 150 caracteres")]
        public string Email { get; set; }

        public bool IsValid { get; set; }

        public IEnumerable<string> Erros { get; set; 

    }
}