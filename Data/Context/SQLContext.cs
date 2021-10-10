using Data.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<ExamRegistration> ExamRegistrations { get; set; }

        public DbSet<TypeOfExam> TypeOfExams { get; set; }

        public DbSet<AppointmentConsultation> AppointmentConsultations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(new PatientMap().Configure);

            modelBuilder.Entity<ExamRegistration>(new ExamRegistrationMap().Configure);

            modelBuilder.Entity<TypeOfExam>(new TypeOfExamMap().Configure);

            modelBuilder.Entity<AppointmentConsultation>(new AppointmentConsultationMap().Configure);


        }
    }


}
