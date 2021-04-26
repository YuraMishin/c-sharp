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
      Console.Write("Количество элементов: ");
      int n = int.Parse(Console.ReadLine());
      int[] numbs = new int[n];
      Console.WriteLine("Исходный массив: ");
      var random = new Random();
      for (int i = 0; i < numbs.Length; i++)
      {
        numbs[i] = random.Next(0, 2);
        Console.Write($"{numbs[i]} ");
      }
      Console.WriteLine();
      Console.WriteLine();
      int head = 0;
      int tail = numbs.Length - 1;
      bool flag = true;
      while (head < tail)
      {
        if (flag)
        {
          if (numbs[head] == 1) flag = false;
          else head++;
        }
        else
        {
          if (numbs[tail] == 0) flag = true;
          else tail--;
        }
        if (numbs[head] == 1 && numbs[tail] == 0)
        {
          int temp = numbs[head];
          numbs[head] = numbs[tail];
          numbs[tail] = temp;

          head++;
          tail--;
        }
      }
      Console.WriteLine("Получившийся массив: ");
      for (int i = 0; i < numbs.Length; i++)
      {
        Console.Write($"{numbs[i]} ");
      }
      Console.ReadKey();
    }
  }
}
