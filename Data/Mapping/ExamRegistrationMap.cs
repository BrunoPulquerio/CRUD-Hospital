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
    class ExamRegistrationMap
    {
        public void Configure(EntityTypeBuilder<ExamRegistration> builder)
        {
            builder.ToTable("ExamRegistrations");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(prop => prop.Note)
                .HasColumnName("Note")
                .HasColumnType("varchar(1000)")
                .IsRequired();
        }
    }
}
