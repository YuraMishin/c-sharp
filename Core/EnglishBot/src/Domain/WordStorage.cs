using System;
using System.Collections.Generic;
using System.IO;

namespace Domain
{
  /// <summary>
  /// Class WordStorage
  /// </summary>
  public class WordStorage
  {
    private const string _path = "wordstorage.txt";

    /// <summary>
    /// Method gets all words
    /// </summary>
    /// <returns>Dictionary&lt;string, string&gt;</returns>
    public Dictionary<string, string> GetAllWords()
    {
      try
      {
        var dic = new Dictionary<string, string>();
        if (File.Exists(_path))
        {
          foreach (var line in File.ReadAllLines(_path))
          {
            var words = line.Split('|');
            if (words.Length == 2)
            {
              dic.Add(words[0], words[1]);
            }
          }
        }
        return dic;
      }
      catch (Exception e)
      {
        Console.WriteLine($"Error! {e.Message}");
        return new Dictionary<string, string>();
      }
    }

    /// <summary>
    /// Method adds word
    /// </summary>
    /// <param name="eng">eng</param>
    /// <param name="rus">rus</param>
    public void AddWord(string eng, string rus)
    {
      try
      {
        using var writer = new StreamWriter(_path, true);
        writer.WriteLine($"{eng}|{rus}");
      }
      catch (Exception e)
      {
        Console.WriteLine($"Error! {e.Message}");
      }
    }
  }
}
