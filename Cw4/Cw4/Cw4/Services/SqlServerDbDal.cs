using Cw4.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw4.Services
{
    public class SqlServerDbDal : IStudentDal
    {
        // Connection string for user with SELECT, UPDATE and INSERT premission
        private const string ConString =
            "Data Source=ds-mssql.database.windows.net;" +
            "Initial Catalog=s17476;" +
            "User ID=ReadOnlyUser;" +
            "Password=ReadOnly2021;" +
            "Connect Timeout=60;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        public IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * from Student";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.indexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirtDate = DateTime.Parse(dr["BirthDate"].ToString());
                    st.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                    students.Add(st);
                }
            }


            return students;
        }
    }
}
