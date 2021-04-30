using System;
using System.IO;
using Newtonsoft.Json;

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
      var worker = new Worker
      {
        FirstName = "Ivan",
        LastName = "Ivanov"
      };
      Console.WriteLine($"Before: {worker}");

      var json = JsonConvert.SerializeObject(worker);
      File.WriteAllText("Ivanov.json", json);
      Console.WriteLine();
      json = File.ReadAllText("Ivanov.json");
      worker = JsonConvert.DeserializeObject<Worker>(json);
      Console.WriteLine($"After: {worker}");
      Console.ReadKey();
    }
  }
}
