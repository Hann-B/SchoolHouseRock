using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHouseRock
{
    class Instructor:Department
    {
        //public int DeptID { get; set; }
        public string InstructorName { get; set; }

        public Instructor()
        {

        }
        public Instructor(SqlDataReader reader)
        {
            InstructorName = reader["Name"].ToString();
            //DeptID = (int)reader["DeptID"];
            Id = (int)reader["ID"];
        }
    }
}
