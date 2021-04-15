using Xunit;

namespace SortBubble.Tests
{
  /// <summary>
  /// Class SolutionTest.
  /// Tests Solution class
  /// </summary>
  public class SolutionTest
  {
    /// <summary>
    /// Tests Sort() method
    /// </summary>
    [Fact]
    public void Sort_InputArray_ReturnSortedArray()
    {
      var bubbleSort = new Solution();
      int[] input = { 1, 5, 4, 2, 3, 1, 7, 8, 0, 5 };
      int[] expected = { 0, 1, 1, 2, 3, 4, 5, 5, 7, 8 };
      int[] actual = bubbleSort.Sort(input);

      Assert.Equal(expected, actual);
    }
  }
}
