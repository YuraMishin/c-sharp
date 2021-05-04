using System;
using System.Data.SqlClient;

namespace CLI
{
  /// <summary>
  /// Class Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      var strCon = new SqlConnectionStringBuilder()
      {
        DataSource = @"(localdb)\MSSQLLocalDB",
        InitialCatalog = "Demo",
        IntegratedSecurity = true,
        Pooling = !false
      };
      Console.WriteLine($"Connection string: {strCon.ConnectionString}");

      using var sqlConnection = new SqlConnection
      { ConnectionString = strCon.ConnectionString };
      sqlConnection.StateChange +=
        (s, e) =>
        {
          Console.WriteLine($@"{nameof(sqlConnection)} в состоянии:" +
                            $" {(s as SqlConnection).State}");
          Console.WriteLine();
        };
      Console.WriteLine();
      try
      {
        sqlConnection.Open();
        var sqlQuery = @"
SELECT *
from Workers
";
        var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
        using var reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
          //Console.WriteLine($"{reader[0]} | {reader[1]}");
          //Console.WriteLine($"{reader["Id"]} | {reader["Name"]}");
          //Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)}");
          Console.WriteLine($"{reader.GetValue(0) as int?} | {reader.GetValue(1) as string}");
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
      Console.ReadKey();
    }
  }
}
