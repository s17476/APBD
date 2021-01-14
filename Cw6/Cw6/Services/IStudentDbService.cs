using Cw6.DTO.Requests;
using Cw6.DTO.Responses;


namespace Cw6.Services
{
    public interface IStudentDbService
    {
        public string GetStudents();
        public string GetStudent(string id);
        public EnrollEnrollmentResponse AddStudent(EnrollStudentRequest request);
        public EnrollEnrollmentResponse Promote(EnrollPromotionRequest request);
    }
}
