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
      Console.WriteLine(GetDigit(123));
      Console.ReadKey();
    }

    /// <summary>
    /// Method calculates digit
    /// </summary>
    /// <param name="n">N</param>
    /// <returns>string</returns>
    private static string GetDigit(int n)
    {
      return n < 10 ? n.ToString() : $"{n % 10} {GetDigit(n / 10)}";
    }
  }
}
