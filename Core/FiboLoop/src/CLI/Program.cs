using System;

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
      for (int i = 1; i <= 25; i++)
      {
        Console.WriteLine($"Fib({i,2}) = {FibLoop(i)}");
      }

      Console.ReadKey();
    }

    /// <summary>
    /// Method calculates the Fibo element
    /// </summary>
    /// <param name="N">N</param>
    /// <returns>int</returns>
    static int FibLoop(int N)
    {
      int a1 = 1;
      int a2 = 1;
      int t = a2;

      for (int i = 2; i < N; i++)
      {
        t = a1 + a2;
        a1 = a2;
        a2 = t;
      }

      return t;
    }
  }
}
