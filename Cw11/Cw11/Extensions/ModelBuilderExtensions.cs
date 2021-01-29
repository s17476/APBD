using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var dictDoctor = new List<Doctor>();

            dictDoctor.Add(new Doctor { IdDoctor = -1, FirstName = "Jan", LastName = "Nowak", Email = "j.n@doctor.com" });
            dictDoctor.Add(new Doctor { IdDoctor = -2, FirstName = "Kamil", LastName = "Janowski", Email = "j.n@doctor.com" });
            dictDoctor.Add(new Doctor { IdDoctor = -3, FirstName = "Michał", LastName = "Wolski", Email = "j.n@doctor.com" });
            dictDoctor.Add(new Doctor { IdDoctor = -4, FirstName = "Krzysztof", LastName = "Kowalski", Email = "j.n@doctor.com" });

            modelBuilder.Entity<Doctor>().HasData(dictDoctor);


            var dictPrescription = new List<Prescription>();

            dictPrescription.Add(
                new Prescription
                {
                    IdPrescription = -1,
                    Date = new DateTime(2021, 01, 21),
                    DueDate = new DateTime(2021, 02, 21),
                    IdPatient = -1,
                    IdDoctor = -1
                });
            dictPrescription.Add(
                new Prescription
                {
                    IdPrescription = -2,
                    Date = new DateTime(2021, 01, 12),
                    DueDate = new DateTime(2021, 06, 12),
                    IdPatient = -2,
                    IdDoctor = -2
                });
            dictPrescription.Add(
                new Prescription
                {
                    IdPrescription = -3,
                    Date = new DateTime(2020, 12, 21),
                    DueDate = new DateTime(2021, 12, 21),
                    IdPatient = -3,
                    IdDoctor = -3
                });

            modelBuilder.Entity<Prescription>().HasData(dictPrescription);


            var dictPatient = new List<Patient>();

            dictPatient.Add(new Patient { IdPatient = -1, FirstName = "Michał", LastName = "Michalczewski", BirthDate = DateTime.Parse("1990-07-01") });
            dictPatient.Add(new Patient { IdPatient = -2, FirstName = "Tomasz", LastName = "Piaskowy", BirthDate = DateTime.Parse("1990-07-01") });
            dictPatient.Add(new Patient { IdPatient = -3, FirstName = "Adam", LastName = "Szklany", BirthDate = DateTime.Parse("1990-07-01") });
            dictPatient.Add(new Patient { IdPatient = -4, FirstName = "Stanisław", LastName = "Stanowski", BirthDate = DateTime.Parse("1990-07-01") });
            dictPatient.Add(new Patient { IdPatient = -5, FirstName = "Konrad", LastName = "Kwiatkowski", BirthDate = DateTime.Parse("1990-07-01") });

            modelBuilder.Entity<Patient>().HasData(dictPatient);


            var dictMedicament = new List<Medicament>();

            dictMedicament.Add(new Medicament { IdMedicament = -1, Name = "PainKiller 3000", Desciption = "some description", Type = "pill" });
            dictMedicament.Add(new Medicament { IdMedicament = -2, Name = "Cough Syrup", Desciption = "some description", Type = "syrup" });
            dictMedicament.Add(new Medicament { IdMedicament = -3, Name = "COVID-19 Vaccine", Desciption = "some description", Type = "injection" });

            modelBuilder.Entity<Medicament>().HasData(dictMedicament);


            var dictPrescriptionMedicament = new List<PrescriptionMedicament>();

            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -1, IdPrescription = -1, Dose = 50, Details = "before meal" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -2, IdPrescription = -1, Dose = 150, Details = "after meal" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -3, IdPrescription = -1, Dose = 250, Details = "n/a" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -1, IdPrescription = -2, Dose = 50, Details = "before meal" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -2, IdPrescription = -2, Dose = 150, Details = "after meal" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -3, IdPrescription = -2, Dose = 250, Details = "n/a" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -1, IdPrescription = -3, Dose = 50, Details = "before meal" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -2, IdPrescription = -3, Dose = 150, Details = "after meal" });
            dictPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = -3, IdPrescription = -3, Dose = 250, Details = "n/a" });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(dictPrescriptionMedicament);
        }
    }
}
