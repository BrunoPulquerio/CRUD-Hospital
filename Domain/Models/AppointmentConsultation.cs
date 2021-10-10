using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AppointmentConsultation:Entity
    {
        public DateTime ExamDate { get; set; }

        public DateTime ConsultationDate { get; set; }

        public int ExamRegistrationId { get; set; }

        public ExamRegistration ExameRegistration { get; set; }

        public int PatientId { get; set; }

        public Patient Patient{ get; set; }
    }
}
