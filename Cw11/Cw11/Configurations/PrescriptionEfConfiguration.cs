using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

            builder.Property(e => e.IdPrescription)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Date)
                    .HasColumnType("date")
                    .IsRequired();

            builder.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .IsRequired();

            builder.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired();

            builder.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired();
        }
    }
}
