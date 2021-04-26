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
      var Z = new double[3, 3];
      Console.WriteLine("Исходная матрица Z[3x3]: ");
      for (int i = 0; i < Z.GetLength(0); i++)
      {
        for (int j = 0; j < Z.GetLength(1); j++)
        {
          Z[i, j] = r.Next(1, 10);
          Console.Write($"{Z[i, j],6} ");
        }

        Console.WriteLine();
      }

      Console.WriteLine();
      Console.WriteLine("Матрица Z[3x3] после преобразования: ");
      for (int i = 0; i < Z.GetLength(0); i++)
      {
        double div = Z[i, i];
        for (int j = 0; j < Z.GetLength(1); j++)
        {
          Z[i, j] /= div;
          Console.Write($"{Math.Round(Z[i, j], 2),6} ");
        }

        Console.WriteLine();
      }

      Console.ReadKey();
    }
  }
}
