using System;
using System.IO;

namespace CLI
{
  /// <summary>
  /// Class Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// Method displays folder and its content
    /// </summary>
    /// <param name="path">path</param>
    /// <param name="trim">trim</param>
    static void GetDir(string path, string trim = "")
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      foreach (var item in directoryInfo.GetDirectories())
      {
        Console.WriteLine($"{trim}{item.Name}");
        GetDir(item.FullName, trim + "  ");
      }
      foreach (var item in directoryInfo.GetFiles())
      {
        Console.WriteLine($"{trim}{item.Name}");
      }
    }

    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      Console.WriteLine("h");
      GetDir(Environment.CurrentDirectory);
      Console.ReadKey();
    }
  }
}
