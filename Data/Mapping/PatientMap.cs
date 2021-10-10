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
    public class PatientMap
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(prop => prop.CPF)
                 .HasColumnName("CPF")
                 .HasColumnType("varchar(11)")
                 .IsRequired();

            builder.Property(prop => prop.Gender)
                .HasColumnName("Gender")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(prop => prop.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar(11)")
                .IsRequired();

        }

    }

}
