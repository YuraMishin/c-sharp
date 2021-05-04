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
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      var connSettings = new SqlConnectionStringBuilder()
      {
        DataSource = @"(localdb)\MSSQLLocalDB",
        InitialCatalog = "Demo",
        IntegratedSecurity = true,
        Pooling = !false
      };
      using var connection = new SqlConnection(connSettings.ConnectionString);

      try
      {
        connection.Open();

        #region Create rows

        string[] sqls =
        {
          "INSERT INTO [dbo].[Workers] ([Name]) VALUES (N'NameTest1')",
          "INSERT INTO [dbo].[Workers] ([Name]) VALUES (N'NameTest2')"
        };
        SqlCommand command;
        Console.WriteLine("Create rows:");
        foreach (var sql in sqls)
        {
          command = new SqlCommand(sql, connection);
          var result = command.ExecuteNonQuery();
          Console.WriteLine($"{result} row(s) added");
        }
        Console.WriteLine();

        #endregion

        #region Read rows

        SelectAll(connection);
        Console.WriteLine();

        #endregion

        #region Update the row

        var sqlUpdate = @"UPDATE Workers SET Name = N'NameTestUpdated' WHERE Name = 'NameTest1'";
        command = new SqlCommand(sqlUpdate, connection);
        var r = command.ExecuteNonQuery();
        Console.WriteLine($"{r} row(s) updated");
        Console.WriteLine();
        SelectAll(connection);
        Console.WriteLine();

        #endregion

        #region Delete the row

        var sqlDelete = @"DELETE FROM Workers WHERE Name = 'NameTestUpdated'";
        command = new SqlCommand(sqlDelete, connection);
        r = command.ExecuteNonQuery();
        Console.WriteLine($"{r} row(s) deleted");
        Console.WriteLine();
        SelectAll(connection);

        #endregion
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      Console.ReadKey();
    }

    /// <summary>
    /// Method selects all the records
    /// </summary>
    /// <param name="connection">connection</param>
    private static void SelectAll(SqlConnection connection)
    {
      SqlCommand command;
      var sqlSelect = @"
SELECT *
from Workers
";
      command = new SqlCommand(sqlSelect, connection);
      using var reader = command.ExecuteReader();
      Console.WriteLine("Read rows:");
      while (reader.Read())
      {
        Console.WriteLine($"{reader[0],6} | {reader[1],10}");
      }
    }
  }
}
