﻿// <auto-generated />
using System;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw11.Migrations
{
    [DbContext(typeof(HealthcareDbContext))]
    [Migration("20210129194515_RelationsFix")]
    partial class RelationsFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw11.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_pk");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = -1,
                            Email = "j.n@doctor.com",
                            FirstName = "Jan",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdDoctor = -2,
                            Email = "j.n@doctor.com",
                            FirstName = "Kamil",
                            LastName = "Janowski"
                        },
                        new
                        {
                            IdDoctor = -3,
                            Email = "j.n@doctor.com",
                            FirstName = "Michał",
                            LastName = "Wolski"
                        },
                        new
                        {
                            IdDoctor = -4,
                            Email = "j.n@doctor.com",
                            FirstName = "Krzysztof",
                            LastName = "Kowalski"
                        });
                });

            modelBuilder.Entity("Cw11.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdMedicament")
                        .HasName("Medicament_pk");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = -1,
                            Desciption = "some description",
                            Name = "PainKiller 3000",
                            Type = "pill"
                        },
                        new
                        {
                            IdMedicament = -2,
                            Desciption = "some description",
                            Name = "Cough Syrup",
                            Type = "syrup"
                        },
                        new
                        {
                            IdMedicament = -3,
                            Desciption = "some description",
                            Name = "COVID-19 Vaccine",
                            Type = "injection"
                        });
                });

            modelBuilder.Entity("Cw11.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdPatient")
                        .HasName("Patient_pk");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = -1,
                            BirthDate = new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Michał",
                            LastName = "Michalczewski"
                        },
                        new
                        {
                            IdPatient = -2,
                            BirthDate = new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tomasz",
                            LastName = "Piaskowy"
                        },
                        new
                        {
                            IdPatient = -3,
                            BirthDate = new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Adam",
                            LastName = "Szklany"
                        },
                        new
                        {
                            IdPatient = -4,
                            BirthDate = new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Stanisław",
                            LastName = "Stanowski"
                        },
                        new
                        {
                            IdPatient = -5,
                            BirthDate = new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Konrad",
                            LastName = "Kwiatkowski"
                        });
                });

            modelBuilder.Entity("Cw11.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<int?>("IdDoctor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdPatient")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_pk");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = -1,
                            Date = new DateTime(2021, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = -1,
                            IdPatient = -1
                        },
                        new
                        {
                            IdPrescription = -2,
                            Date = new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = -2,
                            IdPatient = -2
                        },
                        new
                        {
                            IdPrescription = -3,
                            Date = new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = -3,
                            IdPatient = -3
                        });
                });

            modelBuilder.Entity("Cw11.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int?>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int?>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription")
                        .HasName("Multiple_pk");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = -1,
                            IdPrescription = -1,
                            Details = "before meal",
                            Dose = 50
                        },
                        new
                        {
                            IdMedicament = -2,
                            IdPrescription = -1,
                            Details = "after meal",
                            Dose = 150
                        },
                        new
                        {
                            IdMedicament = -3,
                            IdPrescription = -1,
                            Details = "n/a",
                            Dose = 250
                        },
                        new
                        {
                            IdMedicament = -1,
                            IdPrescription = -2,
                            Details = "before meal",
                            Dose = 50
                        },
                        new
                        {
                            IdMedicament = -2,
                            IdPrescription = -2,
                            Details = "after meal",
                            Dose = 150
                        },
                        new
                        {
                            IdMedicament = -3,
                            IdPrescription = -2,
                            Details = "n/a",
                            Dose = 250
                        },
                        new
                        {
                            IdMedicament = -1,
                            IdPrescription = -3,
                            Details = "before meal",
                            Dose = 50
                        },
                        new
                        {
                            IdMedicament = -2,
                            IdPrescription = -3,
                            Details = "after meal",
                            Dose = 150
                        },
                        new
                        {
                            IdMedicament = -3,
                            IdPrescription = -3,
                            Details = "n/a",
                            Dose = 250
                        });
                });

            modelBuilder.Entity("Cw11.Models.Prescription", b =>
                {
                    b.HasOne("Cw11.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("Doctor_Prescription")
                        .IsRequired();

                    b.HasOne("Cw11.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .HasConstraintName("Patient_Prescription")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Cw11.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Cw11.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .HasConstraintName("Medicament_PrescriptionMedicament")
                        .IsRequired();

                    b.HasOne("Cw11.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
