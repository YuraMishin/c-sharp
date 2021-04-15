using FluentAssertions;
using Xunit;

namespace Domain.UnitTests
{
  /// <summary>
  /// LinkedListNodeTest.
  /// Tests LinkedListNode class.
  /// </summary>
  public class LinkedListNodeTest
  {
    /// <summary>
    /// Tests instance creation.
    /// </summary>
    [Fact]
    public void NotNull_ReturnsTrue_WhenTests()
    {
      var first = new LinkedListNode<int>(2);
      Assert.NotNull(first);
      first.Should().NotBeNull();
    }

    /// <summary>
    /// Tests instance type.
    /// </summary>
    [Fact]
    public void IsType_ReturnsTrue_WhenTest()
    {
      var first = new LinkedListNode<int>(2);

      Assert.IsType<LinkedListNode<int>>(first);
      first.Should().BeOfType<LinkedListNode<int>>();
    }

    /// <summary>
    /// Tests Value() method.
    /// </summary>
    [Fact]
    public void Value_Returns2_WhenInvoke()
    {
      var first = new LinkedListNode<int>(2);

      Assert.Equal(2, first.Value);
    }

    /// <summary>
    /// Tests Next() method.
    /// </summary>
    [Fact]
    public void Next_ReturnsNull_WhenInvoke()
    {
      var first = new LinkedListNode<int>(2);

      Assert.Null(first.Next);
    }

    /// <summary>
    /// Tests Next() method.
    /// </summary>
    [Fact]
    public void Next_IsTypeLinkedListNode_WhenInvoke()
    {
      var first = new LinkedListNode<int>(2);
      var second = new LinkedListNode<int>(3);
      first.Next = second;

      Assert.NotNull(first.Next);
      Assert.IsType<LinkedListNode<int>>(first.Next);
    }

    /// <summary>
    /// Tests Next(), Value() methods.
    /// </summary>
    [Fact]
    public void Value_GetsAllValues_WhenInvoke()
    {
      var first = new LinkedListNode<int>(2);
      var second = new LinkedListNode<int>(3);
      first.Next = second;

      Assert.Equal(2, first.Value);
      Assert.Equal(3, first.Next.Value);
    }
  }
}
