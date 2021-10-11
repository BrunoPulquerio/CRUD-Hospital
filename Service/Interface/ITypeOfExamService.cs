using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITypeOfExamService
    {
        IEnumerable<TypeOfExamViewModel> GetAll();

        TypeOfExamViewModel GetbyId(int Id);

        TypeOfExamViewModel Create(TypeOfExamViewModel obj);

        TypeOfExamViewModel Update(TypeOfExamViewModel obj);

        TypeOfExamViewModel Delete(int Id);

    }
}