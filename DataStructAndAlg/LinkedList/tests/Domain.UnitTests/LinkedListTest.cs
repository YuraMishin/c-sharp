using FluentAssertions;
using Xunit;

namespace Domain.UnitTests
{
  /// <summary>
  /// Class LinkedListTest.
  /// Tests LinkedList class.
  /// </summary>
  public class LinkedListTest
  {
    /// <summary>
    /// Tests instance.
    /// </summary>
    [Fact]
    public void NotNull_IsTrue_WhenInvoke()
    {
      var list = new LinkedList<int>();

      Assert.NotNull(list);
      list.Should().NotBeNull();
    }

    /// <summary>
    /// Tests instance.
    /// </summary>
    [Fact]
    public void IsType_IsTrue_WhenInvoke()
    {
      var list = new LinkedList<int>();

      Assert.IsType<LinkedList<int>>(list);
      list.Should().BeOfType<LinkedList<int>>();
    }

    /// <summary>
    /// Tests Count() method.
    /// </summary>
    [Fact]
    public void Count_Is0_WhenTestEmpryList()
    {
      var list = new LinkedList<int>();

      Assert.Equal(0, list.Count);
    }

    /// <summary>
    /// Tests Count() method.
    /// </summary>
    [Fact]
    public void Count_Is1_WhenTest()
    {
      var list = new LinkedList<int>();
      list.Add(2);

      Assert.Equal(1, list.Count);
    }

    /// <summary>
    /// Tests Count() method.
    /// </summary>
    [Fact]
    public void HeadTail_IsNull_WhenTestEmptyList()
    {
      var list = new LinkedList<int>();

      Assert.Null(list._tail);
      Assert.Null(list._head);
    }

    /// <summary>
    /// Tests Head and Tail values.
    /// </summary>
    [Fact]
    public void HeadTail_IsNotNull_WhenTestNotEmptyList()
    {
      var list = new LinkedList<int>();
      list.Add(2);

      Assert.NotNull(list._tail);
      Assert.NotNull(list._head);
    }

    /// <summary>
    /// Tests Head and Tail values.
    /// </summary>
    [Fact]
    public void HeadTail_Gets2_WhenAddSingleValue()
    {
      var list = new LinkedList<int>();
      list.Add(2);

      Assert.Equal(2, list._tail.Value);
      Assert.Equal(2, list._head.Value);
    }

    /// <summary>
    /// Tests Contains() method.
    /// </summary>
    [Fact]
    public void Contains_IsTrue_WhenAdd2()
    {
      var list = new LinkedList<int>();
      list.Add(2);

      Assert.True(list.Contains(2));
    }

    /// <summary>
    /// Tests Contains() method.
    /// </summary>
    [Fact]
    public void Contains_IsTrue_WhenAdd1Add2()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);

      Assert.True(list.Contains(1));
      Assert.True(list.Contains(2));
    }

    /// <summary>
    /// Tests Contains() method.
    /// </summary>
    [Fact]
    public void Contains_IsFalse_WhenTest()
    {
      var list = new LinkedList<int>();
      list.Add(2);

      Assert.False(list.Contains(1));
    }

    /// <summary>
    /// Tests Remove() method.
    /// </summary>
    [Fact]
    public void Remove_IsTrue_WhenRemoveFromHead()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);

      Assert.True(list.Contains(5));
      Assert.True(list.Remove(5));
      Assert.False(list.Contains(5));
    }

    /// <summary>
    /// Tests Remove() method.
    /// </summary>
    [Fact]
    public void Remove_IsTrue_WhenRemoveFromTail()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);

      Assert.True(list.Contains(1));
      Assert.True(list.Remove(1));
      Assert.False(list.Contains(1));
    }

    /// <summary>
    /// Tests Remove() method.
    /// </summary>
    [Fact]
    public void Remove_IsTrue_WhenRemoveFromMiddle()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);

      Assert.True(list.Contains(3));
      Assert.True(list.Remove(3));
      Assert.False(list.Contains(3));
    }

    /// <summary>
    /// Tests Remove() method.
    /// </summary>
    [Fact]
    public void Remove_IsTrue_WhenRemoveSingle()
    {
      var list = new LinkedList<int>();
      list.Add(1);

      Assert.True(list.Contains(1));
      Assert.True(list.Remove(1));
      Assert.False(list.Contains(1));
    }

    /// <summary>
    /// Tests Remove() method.
    /// </summary>
    [Fact]
    public void Remove_IsFalse_WhenTest()
    {
      var list = new LinkedList<int>();
      list.Add(1);

      Assert.False(list.Remove(3));
    }

    /// <summary>
    /// Tests GetEnumerator() method.
    /// </summary>
    [Fact]
    public void GetEnumerator_IsTrue_WhenTest()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);

      var enumerator = list.GetEnumerator();
      Assert.NotNull(enumerator);
      Assert.True(enumerator.MoveNext());
      Assert.Equal(1, enumerator.Current);
      Assert.True(enumerator.MoveNext());
      Assert.Equal(2, enumerator.Current);
      Assert.False(enumerator.MoveNext());
    }

    /// <summary>
    /// Tests Clear() method.
    /// </summary>
    [Fact]
    public void Clear_ReturnsVoid_WhenInvoke()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);

      Assert.Equal(2, list.Count);

      list.Clear();
      Assert.Equal(0, list.Count);
    }

    /// <summary>
    /// Tests CopyTo() method.
    /// </summary>
    [Fact]
    public void CopyTo_ReturnsArray_WhenInvoke()
    {
      var list = new LinkedList<int>();
      list.Add(1);
      list.Add(2);
      int[] ints = new int[list.Count];

      list.CopyTo(ints, 0);

      Assert.Contains(1, ints);
      Assert.Contains(2, ints);
    }
  }
}
