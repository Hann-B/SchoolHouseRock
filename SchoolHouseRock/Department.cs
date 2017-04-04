using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHouseRock
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadInstructor { get; set; }
        public int DeptCode { get; set; }

        public Department()
        {

        }
        public Department(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            DeptCode = (int)reader["DeptCode"];
            Id = (int)reader["ID"];
            HeadInstructor = (int)reader["HeadInstructor"];
        }
    }
}
