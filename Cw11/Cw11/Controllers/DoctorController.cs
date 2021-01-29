using Cw11.DTO.Request;
using Cw11.Models;
using Cw11.Services;
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
        private readonly IHealthDbService _db;

        public DoctorController(IHealthDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetDoctor()
        {
            return Ok(_db.GetDoctor());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(_db.GetDoctor(id));
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorAddRequestDto doctor)
        {
            try
            {
                _db.AddDoctor(doctor);
            }
            catch(Exception exc)
            {
                return BadRequest(exc.Message);
            }
            return Created("", null);
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorUpdateRequestDto doctor)
        {
            try
            {
                Doctor updatedDoc = _db.UpdateDoctor(doctor);

                if (updatedDoc == null)
                    return NotFound();

                return Ok(updatedDoc);
            }
            catch(Exception exc)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                var deleted = _db.DeleteDoctor(id);
                if (deleted) return Ok();
            }
            catch (Exception exc)
            {
                return NotFound(exc.Message);
            }

            return BadRequest();
        }
    }
}
