using System;
using System.Collections.Generic;
using System.Linq;
using CLI.Data;
using CLI.Models;
using Microsoft.EntityFrameworkCore;

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
      Console.WriteLine("Hello World!");

      var optInMemory = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "test.db")
        .Options;
      var optSQLite = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite(@$"Data Source=test.db")
        .Options;


      try
      {
        using var db = new AppDbContext(optInMemory);
        if (db.Database.EnsureCreated())
        {
          Console.WriteLine("DB exists");
        }
        // create
        var employee1 = new Employee { Name = "Name1" };
        var employee2 = new Employee { Name = "Name2" };
        var storagEmployees = new List<Employee> { employee1, employee2 };
        foreach (var employee in storagEmployees)
        {
          db.Employees.Add(employee);
        }
        var result = db.SaveChanges();
        Console.WriteLine($"Create records. {result} records added.");
        Console.WriteLine();

        //read
        SelectAll(db);

        //update
        var employeeN1 = db.Employees.FirstOrDefault();
        if (employeeN1 != null)
        {
          employeeN1.Name = "NameUpdated";
          db.Update(employeeN1);
          result = db.SaveChanges();
        }

        Console.WriteLine($"Updated {result} record");
        SelectAll(db);

        //delete
        employeeN1 = db.Employees.FirstOrDefault();
        if (employeeN1 != null)
        {
          db.Employees.Remove(employeeN1);
          result = db.SaveChanges();
        }

        Console.WriteLine($"Deleted {result} record");
        SelectAll(db);
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
    /// <param name="db">db</param>
    private static void SelectAll(AppDbContext db)
    {
      Console.WriteLine("Read All records");
      foreach (var employee in db.Employees.ToList())
      {
        Console.WriteLine($"{employee.Id}. {employee.Name}");
      }

      Console.WriteLine();
    }
  }
}
