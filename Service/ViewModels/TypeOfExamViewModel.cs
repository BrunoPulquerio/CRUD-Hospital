using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{

    public class TypeOfExamViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Exame")]
        [Required(ErrorMessage = "Preencha o campo Tipo de Exame")]
        [MaxLength(100, ErrorMessage = "O campo precisa ter no maximo 100 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Descrição do Exame")]
        [Required(ErrorMessage = "Preencha o campo Descrição do Exame")]
        [MaxLength(1000, ErrorMessage = "O campo precisa ter no maximo 100 caracteres")]
        public string Description { get; set; }
        public bool IsValid { get; set; }

        public IList<string> Erros { get; set; }
    }
}