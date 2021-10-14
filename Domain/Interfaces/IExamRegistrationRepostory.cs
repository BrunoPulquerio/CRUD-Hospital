using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface  IExamRegistrationRepostory 
    {
        IEnumerable<ExamRegistration> GetAll();

        ExamRegistration GetById(int id);

        IEnumerable<ExamRegistration> GetByTypeOfExam(int idTypeOfExam);
        int GetTotal();


    }
}
