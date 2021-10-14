using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting.IOC
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));
            services.AddScoped(typeof(IExamRegistrationService), typeof(ExamRegistrationService));
            services.AddScoped(typeof(ITypeOfExamService), typeof(TypeOfExamService));
            services.AddScoped(typeof(IAppointmentConsultationService), typeof(AppointmentConsultationService));
            services.AddScoped(typeof(IExamRegistrationRepostory), typeof(ExamRegistrationRepository));
            services.AddScoped(typeof(IAppointmentConsultationRepository), typeof(AppointmentConsultationRepository));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));
            services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
        }
    }
}
