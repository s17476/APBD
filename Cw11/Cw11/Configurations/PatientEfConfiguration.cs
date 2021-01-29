using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

            builder.Property(e => e.IdPatient)
                .ValueGeneratedOnAdd();


            builder.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .IsRequired();

            builder.HasMany(d => d.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Patient_Prescription");
        }
    }
}
