using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament)
                .HasName("Medicament_pk");

            builder.Property(e => e.IdMedicament)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Desciption)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(e => e.PrescriptionMedicaments)
                .WithOne(p => p.Medicament)
                .HasForeignKey(d => new { d.IdMedicament, d.IdPrescription })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Medicament_PrescriptionMedicament");
        }
    }
}
