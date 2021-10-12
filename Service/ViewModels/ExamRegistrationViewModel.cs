using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class ExamRegistrationViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Nome do Exame")]
        [Required(ErrorMessage = "Preencha o campo Nome do Exame")]
        [MaxLength(100, ErrorMessage = "O Campo precisa ter no maximo 100 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Observações")]
        [Required(ErrorMessage = "Preencha o campo Observações")]
        [MaxLength(1000, ErrorMessage = "O Campo precisa ter no maximo 1000 caracteres")]
        public string Note { get; set; }

        [Display(Name = "Id do Paciente")]
        [Required(ErrorMessage = "Erro no campo Id do Paciente")]
        public int TypeOfExamId { get; set; }

        public TypeOfExamViewModel TypeOfExam { get; set; }

    }
}
