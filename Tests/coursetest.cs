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


        [Fact]
        public void Equals_ReturnsTrueForSameName_true()
        {
            Course firstCourse = new Course("Music", 123);
            Course secondCourse = new Course("Music", 123);

            Assert.Equal (firstCourse, secondCourse);
        }

        [Fact]
        public void Save_ReturnsIdForNewCourse_true()
        {
            Course newCourse = new Course("Music", 123);
            newCourse.Save();

            List<Course> result = Course.GetAll();
            List<Course> testList = new List<Course>{newCourse};


            Assert.Equal(testList, result);
        }

        [Fact]
        public void GetId_GetsIdForCourse_true()
        {
            //Arrange
            Course testCourse = new Course("Music", 123);
            testCourse.Save();

            //Act
            Course savedCourse = Course.GetAll()[0];

            int result = savedCourse.GetId();
            int testId = testCourse.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        public void Dispose()
        {
            Course.DeleteAll();
            Student.DeleteAll();
        }
    }
}
