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
        private IPasswordHashingService _pswdService;

        public EnrollmentsController(IStudentDbService DbService, IPasswordHashingService pswdService)
        {
            _service = DbService;
            _pswdService = pswdService;
        }

        [Authorize(Roles ="Employee")]
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            return Created("", _service.AddStudent(request, _pswdService));
        }

        [Authorize(Roles ="Employee")]
        [HttpPost("promotions")]
        public IActionResult Promote(EnrollPromotionRequest request)
        {
            return Created("", _service.Promote(request));
        }
    }
}
