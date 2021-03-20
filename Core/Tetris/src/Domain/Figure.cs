namespace Domain
{
  /// <summary>
  /// Class Figure
  /// </summary>
  public abstract class Figure
  {
    const int LENGHT = 4;

    /// <summary>
    /// Points
    /// </summary>
    public Point[] Points = new Point[LENGHT];

    /// <summary>
    /// Method draws point
    /// </summary>
    public void Draw()
    {
      foreach (Point p in Points)
      {
        p.Draw();
      }
    }

    /// <summary>
    /// Method tries moving figure
    /// </summary>
    /// <param name="dir">dir</param>
    /// <returns>Result</returns>
    public Result TryMove(Direction dir)
    {
      Hide();

      Move(dir);

      var result = VerityPosition();
      if (result != Result.SUCCESS)
        Move(Reverse(dir));

      Draw();
      return result;
    }

    /// <summary>
    /// Method tries rotating
    /// </summary>
    /// <returns>Result</returns>
    public Result TryRotate()
    {
      Hide();
      Rotate();

      var result = VerityPosition();
      if (result != Result.SUCCESS)
        Rotate();

      Draw();
      return result;
    }

    private Result VerityPosition()
    {
      foreach (var p in Points)
      {
        if (p.Y >= Field.Height)
          return Result.DOWN_BORDER_SRIKE;

        if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
          return Result.BORDER_STRIKE;

        if (Field.CheckStrike(p))
          return Result.HEAP_STRIKE;
      }
      return Result.SUCCESS;
    }

    /// <summary>
    /// Method checks if figure is on top
    /// </summary>
    /// <returns>bool</returns>
    public bool IsOnTop()
    {
      return Points[0].Y == 0;
    }

    /// <summary>
    /// Method moves figure
    /// </summary>
    /// <param name="dir">direction</param>
    public void Move(Direction dir)
    {
      foreach (var p in Points)
      {
        p.Move(dir);
      }
    }

    private Direction Reverse(Direction dir)
    {
      switch (dir)
      {
        case Direction.LEFT:
          return Direction.RIGHT;
        case Direction.RIGHT:
          return Direction.LEFT;
        case Direction.DOWN:
          return Direction.UP;
        case Direction.UP:
          return Direction.DOWN;
      }
      return dir;
    }

    /// <summary>
    /// Method rotates figure
    /// </summary>
    public abstract void Rotate();

    /// <summary>
    /// Method hides figure
    /// </summary>
    public void Hide()
    {
      foreach (Point p in Points)
      {
        p.Hide();
      }
    }

  }
}
