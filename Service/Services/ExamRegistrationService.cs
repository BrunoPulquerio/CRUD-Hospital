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
    public class ExamRegistrationService : IExamRegistrationService
    {
        private readonly IBaseRepository<ExamRegistration> _baseRepository;
        private readonly IExamRegistrationRepostory _examRegistrationRepostory;
        private readonly IMapper _mapper;

        public ExamRegistrationService(IBaseRepository<ExamRegistration> baseRepository, 
            IExamRegistrationRepostory examRegistrationRepostory,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _examRegistrationRepostory = examRegistrationRepostory;
            _mapper = mapper;
        }

        public ExamRegistrationViewModel Create(ExamRegistrationViewModel obj)
        {
            ExamRegistrationValidator validator = new ExamRegistrationValidator();
            var examRegistration = _mapper.Map<ExamRegistration>(obj);
            var validationResult = validator.Validate(examRegistration);

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

            _baseRepository.Insert(examRegistration);
            obj.IsValid = true;
            return obj;
        }

        public ExamRegistrationViewModel Delete(int Id)
        {
            _baseRepository.Delete(Id);
            return new ExamRegistrationViewModel() { IsValid = true };
        }

        public IEnumerable<ExamRegistrationViewModel> GetAll()
        {
            var examregistrations = _examRegistrationRepostory.GetAll();
            return _mapper.Map<IEnumerable<ExamRegistrationViewModel>>(examregistrations);
        }

        public ExamRegistrationViewModel GetbyId(int Id)
        {
            var examregistration = _examRegistrationRepostory.GetById(Id);
            return _mapper.Map<ExamRegistrationViewModel>(examregistration);
        }

        public IEnumerable<ExamRegistrationViewModel> GetByTypeOfExam(int idTypeOfExam)
        {
            var examregistrations = _examRegistrationRepostory.GetByTypeOfExam(idTypeOfExam);
            return _mapper.Map<IEnumerable<ExamRegistrationViewModel>>(examregistrations);
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
            obj.IsValid = true;

            return obj;

        }
    }
}
