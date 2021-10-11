using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ExamRegistration:Entity
    {

        public string Name { get; set; }

        public string Note { get; set; }

        public int TypeOfExamId { get; set; }

        public TypeOfExam TypeOfExam { get; set; }

    }
}
