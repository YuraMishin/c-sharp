namespace Domain
{
  /// <summary>
  /// Interface IDrawer
  /// </summary>
  public interface IDrawer
  {
    /// <summary>
    /// Method draws point
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    void DrawPoint(int x, int y);

    /// <summary>
    /// Method hides point
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    void HidePoint(int x, int y);

    /// <summary>
    /// Method writes game over
    /// </summary>
    void WriteGameOver();

    /// <summary>
    /// Method inits field
    /// </summary>
    void InitField();
  }
}
