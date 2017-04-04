using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHouseRock
{
    class Program
    {
        static public List<Courses> GetAllCourses(SqlConnection connection)
        {
            var courses = new List<Courses>();
            
            var sqlCommand = new SqlCommand
                (@"SELECT *
                FROM [dbo].[Course]
                JOIN Instructor ON Instructor.ID=Course.Instructor"
                , connection);
            connection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var course= new Courses(reader);
                courses.Add(course);
            }
            connection.Close();
            return courses;
        }

        static public List<Instructor> GetAllInstructors(SqlConnection connection)
        {
            var instructors = new List<Instructor>();

            var sqlCommand=new SqlCommand
                (@"SELECT *
                    FROM [dbo].[Instructor]"
                    ,connection);
            connection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var instructor = new Instructor(reader);
                instructors.Add(instructor);
            }
            connection.Close();
            return instructors;

        }


            static void Main(string[] args)
        {
            const string connectionString=
                @"Server=localhost\SQLEXPRESS;Database=DotNetUniversity;Trusted_Connection=True;";

            var courses = new List<Courses>();
            using(var connection = new SqlConnection(connectionString))
            {
                courses = GetAllCourses(connection);
                foreach (var course in courses)
                {
                    //Write List of Courses with each instructor
                    Console.WriteLine($"{course.Title}--{course.Instructor.Name}");
                }
            }
            var instructors = new List<Instructor>();
            using(var connection = new SqlConnection(connectionString))
            {
                instructors = GetAllInstructors(connection);
                Console.WriteLine($"Number of Courses: {courses.Count}");         
                Console.WriteLine($"Number of Instructors: {instructors.Count}");
            }
        }
    }
}
