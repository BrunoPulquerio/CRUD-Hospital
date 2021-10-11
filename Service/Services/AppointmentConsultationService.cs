using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AppointmentConsultationService : IAppointmentConsultationService
    {
        private readonly IBaseRepository<AppointmentConsultation> _baseRepository;
        private readonly IMapper _mapper;

        public AppointmentConsultationService(IBaseRepository<AppointmentConsultation> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public AppointmentConsultationViewModel Create(AppointmentConsultationViewModel obj)
        {
            throw new NotImplementedException();
        }

        public AppointmentConsultationViewModel Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppointmentConsultationViewModel> GetAll()
        {
            var appointmentconsultations = _baseRepository.Select();
            return _mapper.Map<IEnumerable<AppointmentConsultationViewModel>>(appointmentconsultations);
        }

        public AppointmentConsultationViewModel GetbyId(int Id)
        {
            var appointmentconsultation = _baseRepository.Select(Id);
            return _mapper.Map<AppointmentConsultationViewModel>(appointmentconsultation);
        }

        public AppointmentConsultationViewModel Update(AppointmentConsultationViewModel obj)
        {

            var appointmentconsultation = _baseRepository.Select(obj.Id);
            if (appointmentconsultation == null)
            {
                throw new Exception("Registro não Encontrado");
            }

            appointmentconsultation.ExamDate = obj.ExamDate;
            appointmentconsultation.ConsultationDate = obj.ConsultationDate;
            appointmentconsultation.ExamRegistrationId = obj.ExamRegistrationId;
            appointmentconsultation.PatientId = obj.PatientId;

            _baseRepository.Update(appointmentconsultation);

            return _mapper.Map<AppointmentConsultationViewModel>(appointmentconsultation);

        }
    }
}
