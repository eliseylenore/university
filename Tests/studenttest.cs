using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace University
{
    public class StudentTest : IDisposable
    {
      public StudentTest()
      {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=cool_database_test;Integrated Security=SSPI;";
      }

      [Fact]
      public void GetAll_StudentEmptyAtFirst_true()
      {
        int result = Student.GetAll().Count;

        Assert.Equal(0, result);
      }

      [Fact]
      public void Equals_ReturnsTrueForSameName_true()
      {
        Student firstStudent = new Student("Sally");
        Student secondStudent = new Student("Sally");

        Assert.Equal(firstStudent, secondStudent);
      }

      [Fact]
      public void Save_ReturnsStudentName_name()
      {
          Student newStudent = new Student("Sally");
          newStudent.Save();

          List<Student> expected = new List<Student>{newStudent};
          List<Student> result = Student.GetAll();

          Assert.Equal(expected, result);
      }

      [Fact]
      public void Find_ReturnsFoundStudent_name()
      {
          Student newStudent = new Student("Sally");
          newStudent.Save();

          Student foundStudent = Student.Find(newStudent.GetId());

          Assert.Equal(newStudent, foundStudent);
      }

      [Fact]
      public void Delete_DeletesIndividualStudent_list()
      {
          Student newStudent1 = new Student("Sally");
          newStudent1.Save();
          Student newStudent2 = new Student("Gretel");
          newStudent2.Save();

          newStudent2.Delete();

          List<Student> expected = new List<Student>{newStudent1};
          List<Student> actual = Student.GetAll();

          Assert.Equal(expected, actual);
      }

      public void Dispose()
       {
           Student.DeleteAll();
       }

    }
}
