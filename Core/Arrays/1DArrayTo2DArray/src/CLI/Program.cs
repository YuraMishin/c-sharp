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
      int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      int[,] b = new int[3, 3];
      int counterA = 0;
      for (int i = 0; i < b.GetLength(0); i++)
      {
        for (int j = 0; j < b.GetLength(1); j++)
        {
          b[i, j] = a[counterA++];
          Console.Write($"{b[i, j]} ");
        }
        Console.WriteLine();
      }
      Console.ReadKey();
    }
  }
}
