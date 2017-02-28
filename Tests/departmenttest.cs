using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace University
{
    public class DepartmentTest : IDisposable
    {
      public DepartmentTest()
      {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=cool_database_test;Integrated Security=SSPI;";
      }

      [Fact]
      public void GetAll_DepartmentEmptyAtFirst_true()
      {
        int result = Department.GetAll().Count;

        Assert.Equal(0, result);
      }

      [Fact]
      public void Equals_ReturnsTrueForSameName_true()
      {
        Department firstDepartment = new Department("Math");
        Department secondDepartment = new Department("Math");

        Assert.Equal(firstDepartment, secondDepartment);
      }

    //   [Fact]
    //   public void Save_ReturnsDepartmentName_name()
    //   {
    //       Department newDepartment = new Department("Math");
    //       newDepartment.Save();
      //
    //       List<Department> expected = new List<Department>{newDepartment};
    //       List<Department> result = Department.GetAll();
      //
    //       Assert.Equal(expected, result);
    //   }
      //
    //   [Fact]
    //   public void Find_ReturnsFoundDepartment_name()
    //   {
    //       Department newDepartment = new Department("Math");
    //       newDepartment.Save();
      //
    //       Department foundDepartment = Department.Find(newDepartment.GetId());
      //
    //       Assert.Equal(newDepartment, foundDepartment);
    //   }
      //

      public void Dispose()
       {
        //    Department.DeleteAll();
       }

    }
}
