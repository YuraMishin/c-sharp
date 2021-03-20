namespace Domain
{

  /// <summary>
  /// Class DrawerProvider
  /// </summary>
  public static class DrawerProvider
  {
    /// <summary>
    /// IDrawer
    /// </summary>
    private static IDrawer _drawer = new ConsoleDrawer();

    /// <summary>
    /// IDrawer getter
    /// </summary>
    public static IDrawer Drawer { get { return _drawer; } }
  }
}
