namespace CLI
{
  /// <summary>
  /// Сlass Worker
  /// </summary>
  public class Worker
  {
    /// <summary>
    /// First Name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
      return $"{FirstName} {LastName}";
    }
  }
}
