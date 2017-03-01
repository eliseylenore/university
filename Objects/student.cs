using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace University
{
    public class Student
    {
        private int _id;
        private string _name;

        public Student(string Name, int Id = 0)
        {
            _id = Id;
            _name = Name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public override bool Equals(System.Object otherStudent)
        {
            if(!(otherStudent is Student))
            {
                return false;
            }
            else
            {
                Student newStudent = (Student) otherStudent;
                bool idEquality = (this.GetId() == newStudent.GetId());
                bool nameEquality = (this.GetName() == newStudent.GetName());
                return (idEquality && nameEquality);
            }
        }

        public static List<Student> GetAll()
        {
            List<Student> AllStudents = new List<Student>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM students;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int studentId = rdr.GetInt32(0);
                string studentName = rdr.GetString(1);

                Student newStudent = new Student(studentName, studentId);
                AllStudents.Add(newStudent);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return AllStudents;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO students (name) OUTPUT INSERTED.id VALUES (@StudentName);", conn);

            SqlParameter studentName = new SqlParameter();
            studentName.ParameterName = "@StudentName";
            studentName.Value = this._name;

            cmd.Parameters.Add(studentName);

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

        public void Delete()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = mew SqlCommand("DELETE FROM students WHERE id = @StudentId; DELETE FROM classes_student WHERE class_id = @StudentId;", conn);

          SqlParameter studentIdParameter = new SqlParameter;
          studentIdParameter.ParameterName = "@StudentId";
          studentIdParameter.Value = this.GetId();
          cmd.Parameters.Add(studentIdParameter);

          cmd.ExecuteNonQuery();

          if (conn != null)
          {
              conn.Close();
          }
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM students;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static Student Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE id = @studentId;", conn);
            SqlParameter studentIdParameter = new SqlParameter();
            studentIdParameter.ParameterName = "@StudentId";
            studentIdParameter.Value = id.ToString();
            cmd.Parameters.Add(studentIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundStudentId = 0;
            string foundStudentName = null;

            while(rdr.Read())
            {
                foundStudentId = rdr.GetInt32(0);
                foundStudentName = rdr.GetString(1);
            }
            Student foundStudent = new Student(foundStudentName, foundStudentId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundStudent;
        }

    }
}
