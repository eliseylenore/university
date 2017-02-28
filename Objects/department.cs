using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace University
{
    public class Department
    {
        int _id;
        string _name;

        public Department(string Name, int Id = 0)
        {
            _name = Name;
            _id = Id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public static List<Department> GetAll()
        {
            List<Department> AllDepartments = new List<Department>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM departments;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int departmentId = rdr.GetInt32(0);
                string departmentName = rdr.GetString(1);

                Department newDepartment = new Department(departmentName, departmentId);
                AllDepartments.Add(newDepartment);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return AllDepartments;
        }

        public override bool Equals(System.Object otherDepartment)
        {
            if(!(otherDepartment is Department))
            {
                return false;
            }
            else
            {
                Department newDepartment = (Department) otherDepartment;
                bool idEquality = this.GetId() == newDepartment.GetId();
                bool nameEquality = this.GetName() == newDepartment.GetName();
                return (idEquality && nameEquality);
            }
        }
    }
}
