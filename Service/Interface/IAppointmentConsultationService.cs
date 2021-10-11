using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public class IAppointmentConsultationService
    {
        public interface AppointmentConsultationService
        {
            IEnumerable<AppointmentConsultationViewModel> GetAll();

            AppointmentConsultationViewModel GetbyId(int Id);

            AppointmentConsultationViewModel Create(AppointmentConsultationViewModel obj);

            AppointmentConsultationViewModel Update(AppointmentConsultationViewModel obj);

            AppointmentConsultationViewModel Delete(int Id);

        }
    }
}
