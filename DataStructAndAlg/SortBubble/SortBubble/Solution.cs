namespace SortBubble
{
  /// <summary>
  /// Class Solution.
  /// Implements Bubble sort algorithm.
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Method sorts an array
    /// </summary>
    /// <param name="array">Array</param>
    /// <returns>Array</returns>
    public int[] Sort(int[] array)
    {
      bool isSorted;
      for (var i = 0; i < array.Length; i++)
      {
        isSorted = true;
        for (var j = 1; j < array.Length - i; j++)
        {
          if (array[j] < array[j - 1])
          {
            swap(array, j, j - 1);
            isSorted = false;
          }
        }
        if (isSorted)
        {
          return array;
        }
      }
      return array;
    }

    /// <summary>
    /// Method swaps the items
    /// </summary>
    /// <param name="array">Array</param>
    /// <param name="index1">Index1</param>
    /// <param name="index2">Index2</param>
    private void swap(int[] array, int index1, int index2)
    {
      var temp = array[index1];
      array[index1] = array[index2];
      array[index2] = temp;
    }
  }
}
