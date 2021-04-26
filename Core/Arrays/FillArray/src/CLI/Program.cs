using System;

namespace CLI
{
  /// <summary>
  /// Class Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// An application entry point.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Console.Write("Введите n: ");
      int n = int.Parse(Console.ReadLine());

      Random random = new Random();

      int[] numbs = new int[n];

      for (int i = 0; i < numbs.Length; i++)
      {
        numbs[i] = random.Next(-5, 6);
        Console.Write($"{numbs[i]} ");
      }
      Console.ReadKey();
    }
  }
}
