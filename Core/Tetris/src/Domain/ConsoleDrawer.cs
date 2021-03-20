using System;

namespace Domain
{
  /// <summary>
  /// Class ConsoleDrawer
  /// </summary>
  public class ConsoleDrawer : IDrawer
  {
    /// <summary>
    /// Method draws point
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    public void DrawPoint(int x, int y)
    {
      Console.SetCursorPosition(x, y);
      Console.Write('*');
      Console.SetCursorPosition(0, 0);
    }

    /// <summary>
    /// Method hides point
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    public void HidePoint(int x, int y)
    {
      Console.SetCursorPosition(x, y);
      Console.Write(' ');
      Console.SetCursorPosition(0, 0);
    }

    /// <summary>
    /// Method prints game over
    /// </summary>
    public void WriteGameOver()
    {
      Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
      Console.WriteLine("G A M E   O V E R");
    }

    /// <summary>
    /// Method inits CLI window
    /// </summary>
    public void InitField()
    {
      Console.SetWindowSize(Field.Width, Field.Height);
      Console.SetBufferSize(Field.Width, Field.Height);
    }
  }
}
