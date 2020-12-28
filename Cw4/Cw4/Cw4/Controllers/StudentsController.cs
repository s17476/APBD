using Cw4.Services;
using Microsoft.AspNetCore.Mvc;


namespace Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IStudentDal _service;
        public StudentsController(IStudentDal DbService)
        {
            _service = DbService;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }
    }
}
