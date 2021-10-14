using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppointmentConsultationRepository
    {
        IEnumerable<AppointmentConsultation> GetAll();

        AppointmentConsultation GetById(int id);

        AppointmentConsultation GetByDateExamRegistration(DateTime date);

        IEnumerable<AppointmentConsultation> GetLastFiveRegister();

        int GetTotal();
    }
}
