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

        public static Department Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM departments WHERE id = @DepartmentId;", conn);


            SqlParameter departmentIdParameter = new SqlParameter();
            departmentIdParameter.ParameterName = "@DepartmentId";
            departmentIdParameter.Value = id.ToString();
            cmd.Parameters.Add(departmentIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundDepartmentId = 0;
            string foundDepartmentName = null;

            while(rdr.Read())
            {
                foundDepartmentId = rdr.GetInt32(0);
                foundDepartmentName = rdr.GetString(1);
            }
            Department foundDepartment = new Department(foundDepartmentName, foundDepartmentId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundDepartment;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO departments (name) OUTPUT INSERTED.id VALUES (@DepartmentName);", conn);

            SqlParameter departmentName = new SqlParameter();
            departmentName.ParameterName = "@DepartmentName";
            departmentName.Value = this._name;

            cmd.Parameters.Add(departmentName);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM departments;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
