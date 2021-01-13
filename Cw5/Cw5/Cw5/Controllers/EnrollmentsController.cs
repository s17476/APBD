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
            return _service.AddStudent(request, this);
        }

        [HttpPost("promotions")]
        public IActionResult Promote(EnrollPromotionRequest request)
        {
            return _service.Promote(request, this);
        }
    }
}
