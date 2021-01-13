using Cw5.DTO.Requests;
using Cw5.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Created("", _service.AddStudent(request));
        }

        [HttpPost("promotions")]
        public IActionResult Promote(EnrollPromotionRequest request)
        {
            return Created("", _service.Promote(request));
        }
    }
}
