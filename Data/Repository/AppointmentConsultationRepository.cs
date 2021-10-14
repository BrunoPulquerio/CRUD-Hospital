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
    public class AppointmentConsultationRepository : BaseRepository<AppointmentConsultation>, IAppointmentConsultationRepository
    {
        public AppointmentConsultationRepository(SQLContext context) : base(context)
        {
        }
        public IEnumerable<AppointmentConsultation> GetAll()
        {
            var obj = CurrentSet
                      .Include(x => x.ExameRegistration)
                      .Include(x => x.Patient).ToList();

            return obj;
        }

        public AppointmentConsultation GetByDateExamRegistration(DateTime date)
        {
            var obj = CurrentSet
                      .Include(x => x.ExameRegistration)
                        .ThenInclude(x => x.TypeOfExam)
                        .Include(x => x.Patient)
                     .Where(x => x.ExamDate == date)
                     .FirstOrDefault();

            return obj;
        }

        public AppointmentConsultation GetById(int id)
        {
            var obj = CurrentSet
                    .Include(x => x.ExameRegistration)
                     .ThenInclude(x => x.TypeOfExam)
                      .Include(x => x.Patient)
                   .Where(x => x.Id == id)
                   .FirstOrDefault();

            return obj;
        }

        public IEnumerable<AppointmentConsultation> GetLastFiveRegister()
        {
            var obj = CurrentSet
                 .Include(x => x.ExameRegistration)
                  .ThenInclude(x => x.TypeOfExam)
                 .Include(x => x.Patient)
                .Skip(1)
                .Take(5)
                .ToList();

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
