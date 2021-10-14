using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class DashboardViewModel
    {
        public int totalConsultation { get; set; }
        public int totalPatients { get; set; }
        public int totalExams { get; set; }

        public IEnumerable<AppointmentConsultationViewModel> listConsultation { get; set; }
    }
}
