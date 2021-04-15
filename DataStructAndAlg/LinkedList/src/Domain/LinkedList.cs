using System.Collections.Generic;

namespace Domain
{
  /// <summary>
  /// Class LinkedList.
  /// Implements linked list.
  /// </summary>
  /// <typeparam name="T">T</typeparam>
  public class LinkedList<T> : IEnumerable<T>
  {
    /// <summary>
    /// Head
    /// </summary>
    public LinkedListNode<T> _head;
    /// <summary>
    /// Tail
    /// </summary>
    public LinkedListNode<T> _tail;
    /// <summary>
    /// Count
    /// </summary>
    public int Count
    {
      get;
      private set;
    }

    /// <summary>
    /// Method adds a value.
    /// </summary>
    /// <param name="value">value</param>
    public void Add(T value)
    {
      LinkedListNode<T> node = new LinkedListNode<T>(value);
      if (_head == null)
      {
        _head = node;
        _tail = node;
      }
      else
      {
        _tail.Next = node;
        _tail = node;
      }
      Count++;
    }

    /// <summary>
    /// Method removes the value.
    /// </summary>
    /// <param name="item">item</param>
    /// <returns>bool</returns>
    public bool Remove(T item)
    {
      LinkedListNode<T> previous = null;
      LinkedListNode<T> current = _head;

      while (current != null)
      {
        if (current.Value.Equals(item))
        {
          if (previous != null)
          {
            previous.Next = current.Next;
            if (current.Next == null)
            {
              _tail = previous;
            }
          }
          else
          {
            _head = _head.Next;
            if (_head == null)
            {
              _tail = null;
            }
          }
          Count--;
          return true;
        }
        previous = current;
        current = current.Next;
      }
      return false;
    }

    /// <summary>
    /// Method determines if the item exists in the list.
    /// </summary>
    /// <param name="item">item</param>
    /// <returns>bool</returns>
    public bool Contains(T item)
    {
      LinkedListNode<T> current = _head;
      while (current != null)
      {
        if (current.Value.Equals(item))
        {
          return true;
        }
        current = current.Next;
      }
      return false;
    }

    /// <summary>
    /// Method gets enumerator.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator<T> GetEnumerator()
    {
      LinkedListNode<T> current = _head;
      while (current != null)
      {
        yield return current.Value;
        current = current.Next;
      }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }

    /// <summary>
    /// Method clears the list.
    /// </summary>
    public void Clear()
    {
      _head = null;
      _tail = null;
      Count = 0;
    }

    /// <summary>
    /// Method copies the list into the array.
    /// </summary>
    /// <param name="array">array</param>
    /// <param name="arrayIndex">arrayIndex</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
      LinkedListNode<T> current = _head;
      while (current != null)
      {
        array[arrayIndex++] = current.Value;
        current = current.Next;
      }
    }
  }
}
