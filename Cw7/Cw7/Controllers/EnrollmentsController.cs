using Cw7.DTO.Requests;
using Cw7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cw7.Controllers
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

        [Authorize(Roles ="Employee")]
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            return Created("", _service.AddStudent(request));
        }

        [Authorize(Roles ="Employee")]
        [HttpPost("promotions")]
        public IActionResult Promote(EnrollPromotionRequest request)
        {
            return Created("", _service.Promote(request));
        }
    }
}
