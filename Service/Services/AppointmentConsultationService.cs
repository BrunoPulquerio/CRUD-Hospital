using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Service.Interface;
using Service.Validators;
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
        private readonly IAppointmentConsultationRepository _appointmentConsultationRepository;
        private readonly IMapper _mapper;

        public AppointmentConsultationService(IBaseRepository<AppointmentConsultation> baseRepository,
            IAppointmentConsultationRepository appointmentConsultationRepository,
           IMapper mapper)
        {
            _baseRepository = baseRepository;
            _appointmentConsultationRepository = appointmentConsultationRepository;
            _mapper = mapper;
        }

        public AppointmentConsultationViewModel Create(AppointmentConsultationViewModel obj)
        {
            AppointmentConsultationValidator validator = new AppointmentConsultationValidator();
            var appointment = _mapper.Map<AppointmentConsultation>(obj);
            var validationResult = validator.Validate(appointment);

            if (!validationResult.IsValid)
            {
                obj.Erros = new List<string>();
                obj.IsValid = false;
                foreach (var alt in validationResult.Errors)
                {
                    obj.Erros.Add(alt.ErrorMessage.ToString());
                }
                return obj;
            }

            var dateExame = _appointmentConsultationRepository.GetByDateExamRegistration(obj.ExamDate);
            if(dateExame != null)
            {
                obj.Erros = new List<string>();
                obj.IsValid = false;
                var erro = "Exame já registrado no paciente " + dateExame.Patient.Name + " para data: " + obj.ExamDate;
                obj.Erros.Add(erro);
                return obj;
            }


            _baseRepository.Insert(appointment);
            obj.IsValid = true;
            return obj;
        }

        public AppointmentConsultationViewModel Delete(int Id)
        {
            _baseRepository.Delete(Id);
            return new AppointmentConsultationViewModel();
        }

        public IEnumerable<AppointmentConsultationViewModel> GetAll()
        {
            var appointmentconsultations = _appointmentConsultationRepository.GetAll();
            return _mapper.Map<IEnumerable<AppointmentConsultationViewModel>>(appointmentconsultations);
        }

        public AppointmentConsultationViewModel GetbyId(int Id)
        {
            var appointmentconsultation = _appointmentConsultationRepository.GetById(Id);
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
