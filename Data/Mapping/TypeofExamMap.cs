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
    public class TypeOfExamMap
    {
            public void Configure(EntityTypeBuilder<TypeOfExam> builder)
            {
                builder.ToTable("TypeOfExams");

                builder.HasKey(prop => prop.Id);

                builder.Property(prop => prop.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                 builder.Property(prop => prop.Description)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(256)")
                    .IsRequired();

        }

        
    }
}
