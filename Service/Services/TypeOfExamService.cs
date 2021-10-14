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
    public class TypeOfExamService : ITypeOfExamService
    {
        private readonly IBaseRepository<TypeOfExam> _baseRepository;
        private readonly IMapper _mapper;

        public TypeOfExamService(IBaseRepository<TypeOfExam> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public TypeOfExamViewModel Create(TypeOfExamViewModel obj)
        {
            TypeOfExamValidator validator = new TypeOfExamValidator();
            var typeOfExam = _mapper.Map<TypeOfExam>(obj);
            var validationResult = validator.Validate(typeOfExam);

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

            _baseRepository.Insert(typeOfExam);
            obj.IsValid = true;
            return obj;
        }

        public TypeOfExamViewModel Delete(int Id)
        {
            _baseRepository.Delete(Id);
            return new TypeOfExamViewModel() { IsValid = true };
        }

        public IEnumerable<TypeOfExamViewModel> GetAll()
        {
            var typeofexams = _baseRepository.Select();
            return _mapper.Map<IEnumerable<TypeOfExamViewModel>>(typeofexams);
        }

        public TypeOfExamViewModel GetbyId(int Id)
        {
            var typeofexam = _baseRepository.Select(Id);
            return _mapper.Map<TypeOfExamViewModel>(typeofexam);
        }

        public TypeOfExamViewModel Update(TypeOfExamViewModel obj)
        {

            var typeofexam = _baseRepository.Select(obj.Id);
            if (typeofexam == null)
            {
                throw new Exception("Registro não Encontrado");
            }

            typeofexam.Name = obj.Name;
            typeofexam.Description = obj.Description;


            _baseRepository.Update(typeofexam);
            obj.IsValid = true;
            return obj;

        }
    }
}
