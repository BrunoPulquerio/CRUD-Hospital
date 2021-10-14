using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{

    public class AppointmentConsultationViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Data do Exame")]
        [Required(ErrorMessage = "Preencha o campo Data do Exame")]
        public DateTime ExamDate { get; set; }

        [Display(Name = "Data da Consulta")]
        [Required(ErrorMessage = "Preencha o campo Data da Consulta")]
        public DateTime ConsultationDate { get; set; }

        [Display(Name = "Registro do Exame")]
        [Required(ErrorMessage = "Preencha o campo Registro do Exame")]
        public int ExamRegistrationId { get; set; }

        public ExamRegistrationViewModel ExameRegistration { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Preencha o campo Paciente")]
        public int PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        [Display(Name = "Tipo do Exame")]

        public int TypeOfExamId { get; set; }


        public TypeOfExamViewModel TypeOfExam { get; set; }

        public bool IsValid { get; set; }

        public IList<string> Erros { get; set; }

    }
}
