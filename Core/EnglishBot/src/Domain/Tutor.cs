using System;
using System.Collections.Generic;

namespace Domain
{
  /// <summary>
  /// Class Tutor
  /// </summary>
  public class Tutor
  {
    private Dictionary<string, string> _dic;
    private Random _rand;
    private WordStorage _storage;

    /// <summary>
    /// Constructor
    /// </summary>
    public Tutor()
    {
      _rand = new Random();
      _storage = new WordStorage();
      _dic = _storage.GetAllWords();

    }

    /// <summary>
    /// Method adds word
    /// </summary>
    /// <param name="eng">eng</param>
    /// <param name="rus">rus</param>
    public void AddWord(string eng, string rus)
    {
      _dic.Add(eng, rus);
      _storage.AddWord(eng, rus);
    }

    /// <summary>
    /// Method checks word
    /// </summary>
    /// <param name="eng">eng</param>
    /// <param name="rus">rus</param>
    /// <returns>bool</returns>
    public bool CheckWord(string eng, string rus)
    {
      var answer = _dic[eng];
      return answer.ToLower() == rus.ToLower();
    }

    /// <summary>
    /// Method translates word
    /// </summary>
    /// <param name="eng">eng</param>
    /// <returns>string</returns>
    public string Translate(string eng)
    {
      if (_dic.ContainsKey(eng))
      {
        return _dic[eng];
      }

      return null;
    }

    /// <summary>
    /// Method gets random English word
    /// </summary>
    /// <returns>string</returns>
    public string GetRandomEngWord()
    {
      var r = _rand.Next(0, _dic.Count);
      var keys = new List<string>(_dic.Keys);
      return keys[r];
    }
  }
}
