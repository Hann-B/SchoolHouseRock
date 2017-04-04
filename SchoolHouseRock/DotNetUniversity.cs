using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHouseRock
{
    class Courses:Department
    {
        public string Title { get; set; }
        public Instructor Instructor { get; set; }
        public string CourseNumber { get; set; }

        public Courses()
        {

        }

        public Courses(SqlDataReader reader)
        {
            Title = reader["Title"].ToString();
            Id = (int)reader["Id"];
            CourseNumber = reader["CourseNumber"].ToString();
            Instructor = new Instructor()
            {
                Name = reader["Name"].ToString()
            };
        }
    }
}
