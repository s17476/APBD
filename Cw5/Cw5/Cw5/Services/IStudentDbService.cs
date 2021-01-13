using Cw5.DTO.Requests;
using Cw5.DTO.Responses;


namespace Cw5.Services
{
    public interface IStudentDbService
    {
        public string GetStudents();
        public string GetStudent(string id);
        public EnrollEnrollmentResponse AddStudent(EnrollStudentRequest request);
        public EnrollEnrollmentResponse Promote(EnrollPromotionRequest request);
    }
}
