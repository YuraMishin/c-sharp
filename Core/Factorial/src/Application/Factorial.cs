namespace Application
{
  /// <summary>
  /// Class Factorial.
  /// Calculates factorial value
  /// </summary>
  public class Factorial
  {
    /// <summary>
    /// Method calculates factorial
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>int</returns>
    public static int Get(int value)
    {
      if (value <= 1)
      {
        return 1;
      }

      return value * Get(value - 1);
    }
  }
}
