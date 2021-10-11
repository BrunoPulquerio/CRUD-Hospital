using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{

    //FALTA PREENCHER, REGRAS DE NEGOCIO
    public class AppointmentConsultationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Data do Exame")]
        [Required(ErrorMessage = "Preencha o campo Data do Exame")]
        [MaxLength(100, ErrorMessage = "O Campo precisa ter no maximo 100 caracteres")]
        public DateTime ExamDate { get; set; }

        [Display(Name = "Nome do Exame")]
        [Required(ErrorMessage = "Preencha o campo Nome do Exame")]
        [MaxLength(100, ErrorMessage = "O Campo precisa ter no maximo 100 caracteres")]
        public DateTime ConsultationDate { get; set; }

        [Display(Name = "Nome do Exame")]
        [Required(ErrorMessage = "Preencha o campo Nome do Exame")]
        [MaxLength(100, ErrorMessage = "O Campo precisa ter no maximo 100 caracteres")]
        public int ExamRegistrationId { get; set; }

        [Display(Name = "Nome do Exame")]
        [Required(ErrorMessage = "Preencha o campo Nome do Exame")]
        [MaxLength(100, ErrorMessage = "O Campo precisa ter no maximo 100 caracteres")]
        public int PatientId { get; set; }


    }
}
