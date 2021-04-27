using System;

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
      char[] alphabet = { 'y', 'u', 'r', 'a' };
      char[] currentWord = new char[4];

      Find(alphabet, currentWord, 0);
      Console.ReadKey();
    }

    /// <summary>
    /// Method forms the word
    /// </summary>
    /// <param name="Set">Set</param>
    /// <param name="Word">Word</param>
    /// <param name="N">N</param>
    static void Find(char[] Set, char[] Word, int N)
    {
      if (N == Word.Length)
      {
        foreach (var e in Word) { Console.Write(e); }
        Console.WriteLine();
        return;
      }

      char[] tWord = Word;

      for (int i = 0; i < Set.Length; i++)
      {
        tWord[N] = Set[i];
        Find(Set, tWord, N + 1);
      }
    }
  }
}
