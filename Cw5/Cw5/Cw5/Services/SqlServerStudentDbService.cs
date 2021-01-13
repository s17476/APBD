using Cw5.Controllers;
using Cw5.DTO.Requests;
using Cw5.DTO.Responses;
using Cw5.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw5.Services
{
    public class SqlServerStudentDbService: IStudentDbService
    {
        private const string ConString = "Data Source=FRONCZ\\SQLEXPRESS;Initial Catalog=s17476;Integrated Security=True";

        //get all students
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

        //get choosen student
        public string GetStudent(string id)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;

                //in the case of concatenation it is easy to use SQLInjection attack
                com.CommandText = "Select EN.Semester, EN.StartDate, SU.Name " +
                    "from Student ST " +
                    "inner join Enrollment EN on ST.IdEnrollment = EN.IdEnrollment " +
                    "inner join Studies SU on EN.IdStudy = SU.IdStudy " +
                    "where ST.IndexNumber=@id";
                com.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var enr = new Enrollment
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

        public IActionResult AddStudent(EnrollStudentRequest request, EnrollmentsController enroll)
        {
            var _enroll = enroll;

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                
                    com.Connection = con;

                    com.CommandText = "select * from studies where name=@name";
                    com.Parameters.AddWithValue("name", request.Studies);


                    con.Open();

                    var transaction = con.BeginTransaction();
                    com.Transaction = transaction;

                int idStudies;
                int idEnrollment = 1;

                SqlDataReader dr;

                try
                {
                    dr = com.ExecuteReader();
                    //studies doesn't exist
                    if (!dr.Read())
                    {
                        dr.Close();
                        transaction.Rollback();
                        return _enroll.BadRequest("Studies doesn't exist");
                    }

                    idStudies = (int)dr["IdStudy"];
                    dr.Close();

                    com.CommandText = "select MAX(IdEnrollment) as id from enrollment where idstudy=@idstudies and semester=1";
                    com.Parameters.AddWithValue("idstudies", idStudies);

                    //create new enrollment if doesn't exist
                    dr = com.ExecuteReader();
                    if (!dr.Read() || dr["id"] == DBNull.Value)
                    {
                        dr.Close();
                        //get the latest IdEnrollment and set new unique id, else idEnrollment = 1
                        com.CommandText = "select MAX(IdEnrollment) as id from enrollment";
                        dr = com.ExecuteReader();
                        if (dr.Read() && dr["id"] != DBNull.Value)
                        {
                            idEnrollment = (int)dr["id"] + 1;
                        }
                        
                        var studiesStart = DateTime.Today.ToString("yyyy-MM-dd");
                        com.CommandText = "insert into enrollment (IdEnrollment, Semester, IdStudy, StartDate) " +
                            "values (@idEnrollment, 1, @idStudies, @studiesStart)";
                        com.Parameters.AddWithValue("idEnrollment", idEnrollment);
                        com.Parameters.AddWithValue("studiesStart", studiesStart);
                    }
                    else
                    {
                        idEnrollment = (int)dr["id"];
                    }
                    dr.Close();
                    //check if given IndexNumber is unique
                    com.CommandText = "select * from Student where IndexNumber=@indexNumber";
                    com.Parameters.AddWithValue("indexNumber", request.IndexNumber);
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        transaction.Rollback();
                        return _enroll.BadRequest("Student with given index number alleready exists");
                    }
                    dr.Close();
                    //add new student
                    com.CommandText = "insert into student (IndexNumber, FirstName, LastName, BirthDate, IdEnrollment) " +
                        "values (@IndexNumber, @FirstName, @LastName, @BirthDate, @idEnroll)";
                    com.Parameters.AddWithValue("idEnroll", idEnrollment);
                    com.Parameters.AddWithValue("FirstName", request.FirstName);
                    com.Parameters.AddWithValue("LastName", request.LastName);
                    com.Parameters.AddWithValue("BirthDate", request.BirthDate);
                    com.ExecuteNonQuery();

                    
                    //get enrollment from DB
                    com.CommandText = "select * from Enrollment where IdEnrollment=@idEnroll";
                    dr = com.ExecuteReader();
                    var newEnrollment = new EnrollEnrollmentResponse();
                    if(dr.Read())
                    {
                        newEnrollment.IdEnrollment = (int)dr["idEnrollment"];
                        newEnrollment.Semester = (int)dr["semester"];
                        newEnrollment.IdStudies = (int)dr["idstudy"];
                        newEnrollment.StartDate = DateTime.Parse((dr["startDate"].ToString())).ToString("dd.MM.yyyy");
                    }
                    dr.Close();

                    //commit changes and return result
                    transaction.Commit();
                    return _enroll.Created("", newEnrollment);
                }catch(SqlException sql)
                {
                    
                    transaction.Rollback();
                    return _enroll.Problem(sql.Message);
                }
            }

            
        }

        public IActionResult Promote(EnrollPromotionRequest request, EnrollmentsController enroll)
        {
            var _enroll = enroll;

            //using stored procedure
            //The procedure code can be found in the file: ./SQL/PromoteStudents.sql 
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand("PromoteStudents", con))
            {
                //preparing stored procedure
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Studies", request.Studies);
                com.Parameters.AddWithValue("@Semester", request.Semester);

                con.Open();

                SqlDataReader dr;

                try
                {
                    dr = com.ExecuteReader();
                    var newEnrollment = new EnrollEnrollmentResponse();
                    if (dr.Read())
                    {
                        newEnrollment.IdEnrollment = (int)dr["idEnrollment"];
                        newEnrollment.Semester = (int)dr["semester"];
                        newEnrollment.IdStudies = (int)dr["idstudy"];
                        newEnrollment.StartDate = DateTime.Parse((dr["startDate"].ToString())).ToString("dd.MM.yyyy");
                    }
                    dr.Close();

                    return _enroll.Created("", newEnrollment);
                }
                catch (SqlException sql)
                {
                    return _enroll.NotFound(sql.Message);
                }
            }
        }

    }
}
