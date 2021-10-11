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
    public class PatientService:IPatientService
    {
        private readonly IBaseRepository<Patient> _baseRepository;
        private readonly IMapper _mapper; 

        public PatientService(IBaseRepository<Patient> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public PatientViewModel Create(PatientViewModel obj)
        {
            throw new NotImplementedException();
        }

        public PatientViewModel Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientViewModel> GetAll()
        {
            var patients = _baseRepository.Select();
            return _mapper.Map<IEnumerable<PatientViewModel>>(patients);
        }

        public PatientViewModel GetbyId(int Id)
        {
            var patient = _baseRepository.Select(Id);
            return _mapper.Map<PatientViewModel>(patient);
        }

        public PatientViewModel Update(PatientViewModel obj)
        {

            var patient = _baseRepository.Select(obj.Id);
            if (patient == null)
            {
                throw new Exception("Registro não Encontrado");
            }

            patient.Birthday = obj.Birthday;
            patient.Name = obj.Name;
            patient.CPF = obj.CPF;
            patient.Gender = obj.Gender;
            patient.Email = obj.Email;
            patient.PhoneNumber = obj.PhoneNumber;

            _baseRepository.Update(patient);

            return _mapper.Map<PatientViewModel>(patient);

        }
    }
}
