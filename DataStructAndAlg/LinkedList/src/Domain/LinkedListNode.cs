namespace Domain
{
  /// <summary>
  /// Class LinkedListNode.
  /// Implements linked list node.
  /// </summary>
  /// <typeparam name="T">T</typeparam>
  public class LinkedListNode<T>
  {
    /// <summary>
    /// Value
    /// </summary>
    public T Value
    {
      get;
      set;
    }
    /// <summary>
    /// Next
    /// </summary>
    public LinkedListNode<T> Next
    {
      get;
      set;
    }
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">Value</param>
    public LinkedListNode(T value)
    {
      Value = value;
    }
  }
}
