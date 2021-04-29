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
      string compressed = "source.zip";

      using var ss = new FileStream(compressed, FileMode.OpenOrCreate);
      using var ts = File.Create($"{compressed}_unzipped.txt");
      using var ds = new GZipStream(ss, CompressionMode.Decompress);
      ds.CopyTo(ts);
      Console.WriteLine($"{compressed} restored");
      Console.WriteLine("File {0} unzipped. Before: {1}. After: {2}.",
        compressed,
        ss.Length,
        ts.Length);
      Console.ReadKey();
    }
  }
}
