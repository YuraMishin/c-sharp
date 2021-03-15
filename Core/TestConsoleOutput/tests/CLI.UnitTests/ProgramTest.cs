using System;
using System.IO;
using Xunit;

namespace CLI.UnitTests
{
  /// <summary>
  /// Class ProgramTest.
  /// Tests Program class
  /// </summary>
  public class ProgramTest : IDisposable
  {
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;

    /// <summary>
    /// Constructor
    /// </summary>
    public ProgramTest()
    {
      _stringWriter = new StringWriter();
      _originalOutput = Console.Out;
      Console.SetOut(_stringWriter);
    }

    /// <summary>
    /// Tear down method
    /// </summary>
    public void Dispose()
    {
      Console.SetOut(_originalOutput);
      _originalOutput.Dispose();
      _stringWriter.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact(DisplayName = "Main. On launch print string")]
    public void Main_OnLaunch_Print()
    {
      var expected = "Hello World!";

      Program.Main(new string[0]);

      Assert.Equal(expected, _stringWriter.ToString().Trim());
    }
  }
}
