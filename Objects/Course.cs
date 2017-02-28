using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace University
{
    public class Course
    {
        int _id;
        string _name;
        int _number;

        public Course( string Name, int Number, int Id = 0)
        {
            _name = Name;
            _number = Number;
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

        public int GetNumber()
        {
            return _number;
        }

        public static List<Course> GetAll()
        {
            List<Course> AllCourses = new List<Course>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM classes;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int courseId = rdr.GetInt32(0);
                string courseName = rdr.GetString(1);
                int courseNumber = rdr.GetInt32(2);

                Course newCourse = new Course(courseName, courseNumber, courseId);
                AllCourses.Add(newCourse);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return AllCourses;
        }

        public override bool Equals(System.Object otherCourse)
        {
            if (!(otherCourse is Course))
            {
                return false;
            }
            else
            {
                Course newCourse = (Course) otherCourse;
                bool idEquality = this.GetId() == newCourse.GetId();
                bool nameEquality = this.GetName() == newCourse.GetName();
                bool numberEquality = this.GetNumber() == newCourse.GetNumber();
                return (idEquality && nameEquality && numberEquality);
            }
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO classes (name, number) OUTPUT INSERTED.id VALUES(@CourseName, @CourseNumber);", conn);

            SqlParameter courseName = new SqlParameter();
            courseName.ParameterName = "@CourseName";
            courseName.Value = this.GetName();
            cmd.Parameters.Add(courseName);

            SqlParameter courseNumber = new SqlParameter();
            courseNumber.ParameterName = "@CourseNumber";
            courseNumber.Value = this.GetNumber();
            cmd.Parameters.Add(courseNumber);

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
            SqlCommand cmd = new SqlCommand("DELETE FROM classes;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
