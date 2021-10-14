using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ExamRegistrationRepository : BaseRepository<ExamRegistration>, IExamRegistrationRepostory
    {
        public ExamRegistrationRepository(SQLContext context)  : base(context)
        {
        }
        public IEnumerable<ExamRegistration> GetAll()
        {
            var obj = CurrentSet
                      .Include(x => x.TypeOfExam).ToList();

            return obj;
        }

        public ExamRegistration GetById(int id)
        {
            var obj = CurrentSet
                   .Include(x => x.TypeOfExam)
                   .Where(x => x.Id == id)
                   .FirstOrDefault();

            return obj;
        }

        public IEnumerable<ExamRegistration> GetByTypeOfExam(int idTypeOfExam)
        {
            var obj = CurrentSet
                              .Include(x => x.TypeOfExam)
                              .Where(x => x.TypeOfExamId == idTypeOfExam).ToList();

            return obj;
        }

        public int GetTotal()
        {
            var obj = CurrentSet
               .Count();

            return obj;
        }
    }
}