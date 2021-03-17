using Xunit;

namespace Application.UnitTests
{
  /// <summary>
  /// Class SolutionTest.
  /// Tests Solution class
  /// </summary>
  public class SolutionTest
  {
    /// <summary>
    /// Tests GetResult() method
    /// </summary>
    [Fact(DisplayName = "Tests GetResult()")]
    public void GetResult_InputArray_OutputDuplicates()
    {
      var ints = new[] { 1, 2, 3, 1, 3 };
      var expected = new[] { 1, 3 };

      var actual = Solution.GetResult(ints);


      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests GetResultLINQ() method
    /// </summary>
    [Fact(DisplayName = "Tests GetResultLINQ()")]
    public void GetResultLINQ_InputArray_OutputDuplicates()
    {
      var ints = new[] { 1, 2, 3, 1, 3 };
      var expected = new[] { 1, 3 };

      var actual = Solution.GetResultLINQ(ints);


      Assert.Equal(expected, actual);
    }
  }
}
