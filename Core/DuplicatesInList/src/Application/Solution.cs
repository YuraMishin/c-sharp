using System.Collections.Generic;
using System.Linq;

namespace Application
{
  /// <summary>
  /// Class Solution.
  /// Check for duplicates in list 
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Method handles the task
    /// </summary>
    /// <param name="ints">ints</param>
    /// <returns>int[]</returns>
    public static int[] GetResult(int[] ints)
    {
      Dictionary<int, int> dictionary = new Dictionary<int, int>();
      foreach (var item in ints)
      {
        if (dictionary.ContainsKey(item))
        {
          dictionary[item]++;
        }
        else
        {
          dictionary[item] = 1;
        }
      }

      List<int> duplicates = new List<int>();
      foreach (KeyValuePair<int, int> entry in dictionary)
      {
        if (entry.Value > 1)
        {
          duplicates.Add(entry.Key);
        }
      }

      return duplicates.ToArray();
    }

    /// <summary>
    /// Method handles the task via LINQ
    /// </summary>
    /// <param name="ints">ints</param>
    /// <returns>int[]</returns>
    public static int[] GetResultLINQ(int[] ints)
    {
      return ints
        .GroupBy(item => item)
        .Where(g => g.Count() > 1)
        .Select(s => s.Key)
        .ToArray();
    }
  }
}
