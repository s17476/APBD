using Cw11.DTO.Request;
using Cw11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public DoctorController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctor()
        {
            return Ok(_context.Doctors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(_context.Doctors.Where(d => d.IdDoctor == id).ToList());
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorDtoPostRequest doctor)
        {
            return Ok();
        }
    }
}
