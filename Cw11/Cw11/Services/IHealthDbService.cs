using Cw11.DTO.Request;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public interface IHealthDbService
    {
        public IEnumerable<Doctor> GetDoctor();
        public IEnumerable<Doctor> GetDoctor(int id);
        public bool AddDoctor(DoctorAddRequestDto doctor);
        public Doctor UpdateDoctor(DoctorUpdateRequestDto doctor);
        public bool DeleteDoctor(int id);
    }
}
