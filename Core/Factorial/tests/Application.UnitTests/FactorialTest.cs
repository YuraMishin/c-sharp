using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace Application.UnitTests
{
  /// <summary>
  /// Class FactorialTests.
  /// Tests Factorial class
  /// </summary>
  public class FactorialTest
  {
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="output"></param>
    public FactorialTest(ITestOutputHelper output)
    {
      _output = output;
    }

    /// <summary>
    /// Tests Get() method
    /// </summary>
    [Fact(DisplayName = "Get -> Input4 -> Return24")]
    public void Get_Input4_Return24()
    {
      var config = new ConfigurationBuilder()
        .AddJsonFile("config.json")
        .Build();
      var name = config["Name"];

      var expected = 24;
      var actual = Factorial.Get(4);

      _output.WriteLine($"Hello, {name}!");
      Assert.Equal(expected, actual);

      actual.Should().Be(expected);
    }

    /// <summary>
    /// Tests Get() method
    /// </summary>
    /// <param name="input">input</param>
    /// <param name="expected">expected</param>
    [Theory(DisplayName = "Get -> InputBulk -> ReturnCorrect")]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    public void Get_InputBulk_ReturnCorrect(int input, int expected)
    {
      var actual = Factorial.Get(input);

      // Xunit
      Assert.Equal(expected, actual);

      // FluentAssertions
      actual.Should().Be(expected);
    }
  }
}
