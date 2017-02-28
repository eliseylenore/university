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

      public void Dispose()
       {

       }
    }
}
