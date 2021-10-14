using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(SQLContext context) : base(context)
        {
        }

        public Patient GetByCpfOrName(string nameOfCpf)
        {
            var obj = CurrentSet
                 .Where(x => x.Name.Contains(nameOfCpf) || x.CPF.Contains(nameOfCpf))
                 .FirstOrDefault();

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
