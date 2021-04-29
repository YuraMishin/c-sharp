using System;
using System.IO;
using System.IO.Compression;

namespace CLI
{
  /// <summary>
  /// Class Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      string source = "source.txt";
      string compressed = "source.zip";

      using var ss = new FileStream(source, FileMode.OpenOrCreate);
      using var ts = File.Create(compressed);
      using var cs = new GZipStream(ts, CompressionMode.Compress);
      ss.CopyTo(cs);

      Console.WriteLine("Compression {0} is completed. Before: {1}. After: {2}.",
        source,
        ss.Length,
        ts.Length);
      Console.ReadKey();
    }
  }
}
