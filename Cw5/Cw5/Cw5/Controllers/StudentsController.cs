using Cw5.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw5.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentDbService _service;
        public StudentsController(IStudentDbService DbService)
        {
            _service = DbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentsByIndex(string id)
        {
            return Ok(_service.GetStudent(id));
        }
    }
}
