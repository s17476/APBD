using Cw11.DTO.Request;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class HealthSqlDbService : IHealthDbService
    {
        private readonly HealthcareDbContext _context;
        public HealthSqlDbService(HealthcareDbContext context)
        {
            _context = context;
        }
        public bool AddDoctor(DoctorAddRequestDto doctor)
        {
            var newDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            _context.Attach(newDoctor);

            _context.SaveChanges();

            return true;
        }

        public bool DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => doc.IdDoctor == id);

            if (doctor != null)
            {
                _context.Remove(doctor);

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<Doctor> GetDoctor()
        {
           return _context.Doctors.ToList();
        }

        public IEnumerable<Doctor> GetDoctor(int id)
        {
            return _context.Doctors.Where(d => d.IdDoctor == id).ToList();
        }

        public Doctor UpdateDoctor(DoctorUpdateRequestDto doctor)
        {
            var dbDoctor = _context.Doctors.FirstOrDefault(doc => doc.IdDoctor == doctor.IdDoctor);

            if (dbDoctor != null)
            {
                dbDoctor.FirstName = doctor.FirstName;
                dbDoctor.LastName = doctor.LastName;
                dbDoctor.Email = doctor.Email;

                _context.SaveChanges();
            }
            else
            {
                return null;
            }

            return dbDoctor;
        }
    }
}
