using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IExamRegistrationService
    {
        IEnumerable<ExamRegistrationViewModel> GetAll();

        ExamRegistrationViewModel GetbyId(int Id);

        ExamRegistrationViewModel Create(ExamRegistrationViewModel obj);

        ExamRegistrationViewModel Update(ExamRegistrationViewModel obj);

        ExamRegistrationViewModel Delete(int Id);

        IEnumerable<ExamRegistrationViewModel> GetByTypeOfExam(int id);

    }
}
