using Cw5.DTO.Requests;
using Cw5.Models;
using Cw5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw5.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService DbService)
        {
            _service = DbService;
        }


        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {

            

            return _service.AddStudent(request, this);
        }
    }
}
