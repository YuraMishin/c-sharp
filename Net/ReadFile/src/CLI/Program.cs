using System;
using System.IO;
using System.Net;

namespace CLI
{
  /// <summary>
  ///   Class Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      var client = new WebClient();
      using var stream = client.OpenRead("https://filesamples.com/samples/document/txt/sample1.txt");
      using var reader = new StreamReader(stream);
      string line = "";
      while ((line = reader.ReadLine()) != null)
      {
        Console.WriteLine(reader.ReadToEnd());
      }
      Console.WriteLine();
      Console.WriteLine("The file is downloaded");
      Console.ReadKey();
    }
  }
}
