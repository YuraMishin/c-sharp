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
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      int[,] matrix = new int[3, 3];
      Random r = new Random();
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          matrix[i, j] = r.Next(10);
          Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
      }
      Console.ReadKey();
    }
  }
}
