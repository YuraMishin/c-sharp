using System;

namespace CLI
{
  /// <summary>
  /// Class Program.
  /// </summary>
  class Program
  {
    /// <summary>
    /// The application entry point.
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      for (int i = 2; i < 10; i++)
      {
        for (int j = 1; j <= 10; j++)
        {
          Console.WriteLine($"{i} x {j} = {i * j} ");
        }
        Console.WriteLine();
      }
      Console.ReadKey();
    }
  }
}
