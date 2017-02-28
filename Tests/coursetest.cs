using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace University
{
    public class CourseTest : IDisposable
    {
        public CourseTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=cool_database_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_CoursesEmptyAtFirst_ReturnTrue()
        {
            int result = Course.GetAll().Count;
            Assert.Equal(0, result);
        }

        public void Dispose()
         {
            //  Course.DeleteAll();
             Student.DeleteAll();
         }

         [Fact]
         public void Equals_ReturnsTrueForSameName_true()
         {
             Course firstCourse = new Course("Music", 123);
             Course secondCourse = new Course("Music", 123);

             Assert.Equal (firstCourse, secondCourse);
         }
    }
}
