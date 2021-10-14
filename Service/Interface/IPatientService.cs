using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPatientService
    {
        IEnumerable<PatientViewModel> GetAll();

        PatientViewModel GetbyId(int Id);

        PatientViewModel Create(PatientViewModel obj);

        PatientViewModel Update(PatientViewModel obj);

        PatientViewModel Delete(int Id);

        PatientViewModel GetByNameOrCpf(string nameOrCpf);

    }
}
