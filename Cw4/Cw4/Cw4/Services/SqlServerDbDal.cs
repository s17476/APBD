using Cw4.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw4.Services
{
    public class SqlServerDbDal : IStudentDal
    {
        private const string ConString = "Data Source=FRONCZ\\SQLEXPRESS;Initial Catalog=s17476;Integrated Security=True";

        public string GetStudents()
        {


            


            var students = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;

                com.CommandText = "Select ST.FirstName, ST.LastName, ST.BirthDate, SU.Name, EN.Semester " +
                       "from Student ST " +
                       "inner join Enrollment EN on ST.IdEnrollment = EN.IdEnrollment " +
                       "inner join Studies SU on EN.IdStudy = SU.IdStudy";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    students.Add(new Student
                    {
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BirtDate = DateTime.Parse(dr["BirthDate"].ToString()).ToString("dd/MM/yyyy"),
                        IdEnrollment = new Enrollment
                        {
                            Semester = Int32.Parse(dr["Semester"].ToString()),
                            IdStudies = new Studies
                            {
                                Name = dr["Name"].ToString()
                            }
                        }

                    });
                    
                }
            }


            return JsonConvert.SerializeObject(students,
                            Newtonsoft.Json.Formatting.None,
                            //skips null and zero properties
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
        }




        public string GetStudent(string id)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;

                com.CommandText = "Select EN.Semester, EN.StartDate, SU.Name " +
                    "from Student ST " +
                    "inner join Enrollment EN on ST.IdEnrollment = EN.IdEnrollment " +
                    "inner join Studies SU on EN.IdStudy = SU.IdStudy " +
                    "where ST.IndexNumber like '" + id + "'";


                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var enr =  new Enrollment
                    {
                        Semester = Int32.Parse(dr["Semester"].ToString()),
                        StartDate = DateTime.Parse(dr["StartDate"].ToString()).ToString("dd/MM/yyyy"),
                        IdStudies = new Studies
                        {
                            Name = dr["Name"].ToString()
                        }
                    };
                    return JsonConvert.SerializeObject(enr,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                //skips null and zero properties
                                NullValueHandling = NullValueHandling.Ignore
                            });

                }
            }
            return null;
        }
    }
}
