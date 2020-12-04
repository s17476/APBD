using Cw3.Models;

using System.Collections.Generic;


namespace Cw3.Services
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
            new Student{IdStudent=1, FirstName="jan", LastName="Kowalski", IndexNumber="s12122"},
            new Student{IdStudent=2, FirstName="Janina", LastName="Kowcz", IndexNumber="s12442"},
            new Student{IdStudent=3, FirstName="Adam", LastName="Adamczewski", IndexNumber="s15552"}
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
