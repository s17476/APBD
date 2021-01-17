using Cw7.DTO.Requests;
using Cw7.DTO.Responses;


namespace Cw7.Services
{
    public interface IStudentDbService
    {
        public string GetStudents();
        public string GetStudent(string id);
        public EnrollEnrollmentResponse AddStudent(EnrollStudentRequest request, IPasswordHashingService pswdService);
        public EnrollEnrollmentResponse Promote(EnrollPromotionRequest request);

        public StudentLoginResponse Login(LoginRequest request);
        public int AddRefreshToken(string IndexNumber, string newRefToken);
        public StudentLoginResponse UpdateRefreshToken(string oldRefToken, string newRefToken);
    }
}
