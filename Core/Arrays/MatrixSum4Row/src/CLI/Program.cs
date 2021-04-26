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
      Random r = new Random();
      var A = new int[4, 4];
      Console.WriteLine("Matrix A[4x4]: ");
      for (int i = 0; i < A.GetLength(0); i++)
      {
        int sum = 0;
        for (int j = 0; j < A.GetLength(1); j++)
        {
          A[i, j] = r.Next(1, 3);
          sum += A[i, j];
          Console.Write($"{A[i, j],2} ");
        }

        Console.WriteLine($" : Sum {sum}");
      }

      Console.ReadKey();
    }
  }
}
