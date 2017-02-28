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
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=cool_database_test;Integrated Security=SSPI"
      }
    }
}
