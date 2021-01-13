using Cw5.Controllers;
using Cw5.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Cw5.Services
{
    public interface IStudentDbService
    {
        public string GetStudents();
        public string GetStudent(string id);
        public IActionResult AddStudent(EnrollStudentRequest request, EnrollmentsController enroll);
        public IActionResult Promote(EnrollPromotionRequest request, EnrollmentsController enroll);
    }
}
