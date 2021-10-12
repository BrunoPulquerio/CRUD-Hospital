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
    public class ExamRegistrationService : IExamRegistrationService
    {
        private readonly IBaseRepository<ExamRegistration> _baseRepository;
        private readonly IMapper _mapper;

        public ExamRegistrationService(IBaseRepository<ExamRegistration> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public ExamRegistrationViewModel Create(ExamRegistrationViewModel obj)
        {
            throw new NotImplementedException();
        }

        public ExamRegistrationViewModel Delete(int Id)
        {
            _baseRepository.Delete(Id);
            return new ExamRegistrationViewModel();
        }

        public IEnumerable<ExamRegistrationViewModel> GetAll()
        {
            var examregistrations = _baseRepository.Select();
            return _mapper.Map<IEnumerable<ExamRegistrationViewModel>>(examregistrations);
        }

        public ExamRegistrationViewModel GetbyId(int Id)
        {
            var examregistration = _baseRepository.Select(Id);
            return _mapper.Map<ExamRegistrationViewModel>(examregistration);
        }

        public ExamRegistrationViewModel Update(ExamRegistrationViewModel obj)
        {

            var examregistration = _baseRepository.Select(obj.Id);
            if (examregistration == null)
            {
                throw new Exception("Registro não Encontrado");
            }

            examregistration.Name = obj.Name;
            examregistration.Note = obj.Note;


            _baseRepository.Update(examregistration);

            return _mapper.Map<ExamRegistrationViewModel>(examregistration);

        }
    }
}
