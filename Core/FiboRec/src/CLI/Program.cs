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
        Console.WriteLine($"Fib({i,2}) = {Fib(i)}");
      }

      Console.ReadKey();
    }

    private static int Fib(int N)
    {
      return (N == 1 || N == 2) ? 1 : Fib(N - 1) + Fib(N - 2);
    }
  }
}
