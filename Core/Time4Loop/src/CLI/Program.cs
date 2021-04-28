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
      var date = DateTime.Now;
      double sum = 0;
      for (int k = 1; k <= 100; k++)
      {
        sum += k;
      }
      Console.WriteLine($"sum = {sum}");

      TimeSpan timeSpan = DateTime.Now.Subtract(date);
      Console.WriteLine($"timeSpan.TotalMilliseconds = {timeSpan.TotalMilliseconds}");
      Console.ReadKey();
    }
  }
}
