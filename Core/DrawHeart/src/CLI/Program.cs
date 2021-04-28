using System;

namespace CLI
{
  /// <summary>
  /// Class Program
  /// </summary>
  class Program
  {
    static void Print(char[,] Map)
    {
      for (int i = 0; i < Map.GetLength(0); i++)
      {
        for (int j = 0; j < Map.GetLength(1); j++)
        {
          Console.Write(Map[i, j] == '.' ? ' ' : Map[i, j]);
        }

        Console.WriteLine();
      }

      Console.WriteLine();
    }

    /// <summary>
    /// Method fills the pixel
    /// </summary>
    /// <param name="Map">Map</param>
    /// <param name="PosX">PosX</param>
    /// <param name="PosY">PosY</param>
    static void ToColor(char[,] Map, int PosX, int PosY)
    {
      if (Map[PosX, PosY] == '.')
      {
        Map[PosX, PosY] = '+'; // 
        ToColor(Map, PosX - 1, PosY);
        ToColor(Map, PosX, PosY + 1);
        ToColor(Map, PosX + 1, PosY);
        ToColor(Map, PosX, PosY - 1);
      }
    }

    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      char[,] map = new char[,]
      {
        {'.', '+', '+', '.', '+', '+', '.',},
        {'+', '.', '.', '+', '.', '.', '+',},
        {'+', '.', '.', '.', '.', '.', '+',},
        {'.', '+', '.', '.', '.', '+', '.',},
        {'.', '.', '+', '.', '+', '.', '.',},
        {'.', '.', '.', '+', '.', '.', '.',}
      };

      Print(map);
      Console.WriteLine();
      ToColor(map, 1, 1);
      Print(map);
      Console.ReadKey();
    }
  }
}
