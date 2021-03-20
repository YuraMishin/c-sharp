namespace Domain
{
  /// <summary>
  /// Class Point
  /// </summary>
  public class Point
  {
    /// <summary>
    /// X
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Method draws point
    /// </summary>
    public void Draw()
    {
      DrawerProvider.Drawer.DrawPoint(X, Y);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="p">Point</param>
    public Point(Point p)
    {
      X = p.X;
      Y = p.Y;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="a">a</param>
    /// <param name="b">b</param>
    public Point(int a, int b)
    {
      X = a;
      Y = b;
    }

    internal void Move(Direction dir)
    {
      switch (dir)
      {
        case Direction.DOWN:
          Y += 1;
          break;
        case Direction.LEFT:
          X -= 1;
          break;
        case Direction.RIGHT:
          X += 1;
          break;
        case Direction.UP:
          Y -= 1;
          break;
      }
    }

    internal void Hide()
    {
      DrawerProvider.Drawer.HidePoint(X, Y);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public Point() { }

  }
}
