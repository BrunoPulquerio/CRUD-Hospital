using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    class AppointmentConsultationMap
    { 

        public void Configure(EntityTypeBuilder<AppointmentConsultation> builder)
        {
        builder.ToTable("AppointmentConsultations");

        builder.HasKey(prop => prop.Id);

        }
    }
}
