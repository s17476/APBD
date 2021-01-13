using Cw5.Controllers;
using Cw5.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw5.Services
{
    public interface IStudentDbService
    {
        public string GetStudents();
        public string GetStudent(string id);
        public IActionResult AddStudent(EnrollStudentRequest request, EnrollmentsController enroll);
    }
}
