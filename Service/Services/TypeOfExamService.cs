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
            throw new NotImplementedException();
        }

        public TypeOfExamViewModel Delete(int Id)
        {
            _baseRepository.Delete(Id);
            return new TypeOfExamViewModel();
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

            return _mapper.Map<TypeOfExamViewModel>(typeofexam);

        }
    }
}
