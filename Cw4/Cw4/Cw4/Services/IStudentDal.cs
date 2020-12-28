using Cw4.Model;
using System.Collections.Generic;

namespace Cw4.Services
{
    public interface IStudentDal
    {
        public IEnumerable<Student> GetStudents();
    }
}
