using System;
using System.IO;
using System.Text;

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
      var sw = new StreamWriter("db.csv", true, Encoding.Unicode);
      char key;
      do
      {
        var note = "";
        Console.Write("\nAuthor: ");
        note += $"{Console.ReadLine()}\t";

        var now = DateTime.Now.ToShortTimeString();
        Console.WriteLine($"Note time: {now}");
        note += $"{now}\t";

        Console.Write("Note: ");
        note += $"{Console.ReadLine()}\t";

        sw.WriteLine(note);
        Console.Write("Next? y/n ");
        key = Console.ReadKey(true).KeyChar;
        Console.WriteLine();
      } while (char.ToLower(key) == 'y');
      sw.Close();

      using var sr = new StreamReader("db.csv", Encoding.Unicode);
      string line;
      Console.WriteLine($"{"Author",15}{" Note time",8} {"Note"}");
      while ((line = sr.ReadLine()) != null)
      {
        string[] data = line.Split('\t');
        Console.WriteLine($"{data[0],15}{data[1],8} {data[2]}");
      }
      Console.ReadKey();
    }
  }
}
