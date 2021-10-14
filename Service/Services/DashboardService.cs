using AutoMapper;
using Domain.Interfaces;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IAppointmentConsultationRepository _appointmentConsultationRepository;
        private readonly IExamRegistrationRepostory _examRegistrationRepostory;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public DashboardService(IAppointmentConsultationRepository appointmentConsultationRepository,
            IExamRegistrationRepostory examRegistrationRepostory,
            IPatientRepository patientRepository,
            IMapper mapper
           )
        {
            _appointmentConsultationRepository = appointmentConsultationRepository;
            _examRegistrationRepostory = examRegistrationRepostory;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public DashboardViewModel GetDashboard()
        {
            var dashboard = new DashboardViewModel();
            dashboard.totalPatients = _patientRepository.GetTotal();
            dashboard.totalConsultation = _appointmentConsultationRepository.GetTotal();
            dashboard.totalExams = _examRegistrationRepostory.GetTotal();

            dashboard.listConsultation = _mapper.Map<IEnumerable<AppointmentConsultationViewModel>>(_appointmentConsultationRepository.GetLastFiveRegister());

            return dashboard;
        }
    }
}
