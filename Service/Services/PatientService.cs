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
    public class PatientService:IPatientService
    {
        private readonly IBaseRepository<Patient> _baseRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper; 

        public PatientService(IBaseRepository<Patient> baseRepository, IPatientRepository patientRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public PatientViewModel Create(PatientViewModel obj)
        {
         
            PatientValidator validator = new PatientValidator();
            var patient = _mapper.Map<Patient>(obj);
            var validationResult = validator.Validate(patient);

                if (!validationResult.IsValid)
                {
                    obj.Erros = new List<string>();
                    obj.IsValid = false;
                    foreach(var alt in validationResult.Errors)
                    {
                    obj.Erros.Add(alt.ErrorMessage.ToString());
                    }
                    return obj;
                }

                var cpfPatient = _patientRepository.GetByCpfOrName(obj.CPF);

                if(cpfPatient != null)
                {
                    if(obj.CPF == cpfPatient.CPF)
                        {
                        obj.Erros = new List<string>();
                        obj.IsValid = false;
                        obj.Erros.Add("CPF já existe");
                       }

                    return obj;
                }

                _baseRepository.Insert(patient);
                obj.IsValid = true;
                return obj;

        }
        

        public PatientViewModel Delete(int Id)
        {
            _baseRepository.Delete(Id);
            return new PatientViewModel() { IsValid  = true};
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

        public PatientViewModel GetByNameOrCpf(string nameOfCpf)
        {
            var patient = _patientRepository.GetByCpfOrName(nameOfCpf);
            var obj = new Patient();
            if(patient != null)
            {
                obj = patient;
            }
            return _mapper.Map<PatientViewModel>(obj);
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
            obj.IsValid = true;
            return obj;

        }
    }
}
