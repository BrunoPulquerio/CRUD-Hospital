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
            throw new NotImplementedException();
        }
    }
}
