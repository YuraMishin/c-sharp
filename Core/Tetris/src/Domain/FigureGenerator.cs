using System;

namespace Domain
{
  /// <summary>
  /// Class FigureGenerator
  /// </summary>
  public class FigureGenerator
  {
    private int _x;
    private int _y;

    private Random _rand = new Random();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    public FigureGenerator(int x, int y)
    {
      _x = x;
      _y = y;
    }

    /// <summary>
    /// Method gets new figure
    /// </summary>
    /// <returns>Figure</returns>
    public Figure GetNewFigure()
    {
      if (_rand.Next(0, 2) == 0)
        return new Square(_x, _y);
      else
        return new Stick(_x, _y);
    }
  }
}
