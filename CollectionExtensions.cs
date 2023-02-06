using System;
using System.Collections.Generic;

namespace System.Extensions
{
  public static class CollectionExtensions
  {
    #region ICollection

    public static bool IsNullOrEmpty<TSource>(this ICollection<TSource> _coll)
    {
      if (_coll == null)
      {
        return true;
      }

      if (_coll.Count == 0)
      {
        return true;
      }
      return false;
    }
    #endregion

    #region IDictionary

    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> _dict, IEnumerable<KeyValuePair<TKey, TValue>> _value)
    {
      _value?.ForEach(_dict.TryAdd);
    }

    public static int RemoveWhere<TKey, TValue>(this IDictionary<TKey, TValue> _dict, Predicate<TValue> _func)
    {
      Action result = null;
      int count = 0;

      foreach (var kvp in _dict)
      {
        if (_func.Invoke(kvp.Value))
        {
          result += () => _dict.Remove(kvp.Key);
          count++;
        }
      }

      result?.Invoke();
      return count;
    }

    public static int Sum<TKey>(this IDictionary<TKey, int> _dict, TKey _key)
    {
      return _dict.Sum(_key, 1);
    }

    public static int Sum<TKey>(this IDictionary<TKey, int> _dict, TKey _key, int _value)
    {
      bool isGet = _dict.TryGetValue(_key, out int value);

      if (isGet == false)
      {
        _dict.Add(_key, _value);
        return _value;
      }

      value += _value;
      _dict[_key] = value;
      return value;
    }

    public static float Sum<TKey>(this IDictionary<TKey, float> _dict, TKey _key)
    {
      return _dict.Sum(_key, 1);
    }

    public static float Sum<TKey>(this IDictionary<TKey, float> _dict, TKey _key, float _value)
    {
      bool isGet = _dict.TryGetValue(_key, out float value);

      if (isGet == false)
      {
        _dict.Add(_key, _value);
        return _value;
      }

      value += _value;
      _dict[_key] = value;
      return value;
    }

    public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> _dict, TKey _key, TValue _value)
    {
      bool isContain = _dict.ContainsKey(_key);

      if (isContain == true)
      {
        return false;
      }

      _dict.Add(_key, _value);
      return true;
    }

    public static void Update<TKey, TValue>(this IDictionary<TKey, TValue> _dict, TKey _key, TValue _value)
    {
      bool isContain = _dict.ContainsKey(_key);

      if (isContain == false)
      {
        _dict.Add(_key, _value);
        return;
      }
      _dict[_key] = _value;
    }

    public static void UpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> _dict, IEnumerable<KeyValuePair<TKey, TValue>> _value)
    {
      _value?.ForEach(_dict.Update);
    }
    #endregion

    #region IDictionary<TKey, List<TValue>>

    public static void Add<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var list);

      if (isGet == false)
      {
        list = new List<TValue>();
        list.Add(_value);
        _dict.Add(_key, list);
        return;
      }
      list.Add(_value);
    }

    public static void AddRange<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key, List<TValue> _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var list);

      if (isGet == false)
      {
        _dict.Add(_key, _value);
        return;
      }
      list.AddRange(_value);
    }

    public static void Clear<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key)
    {
      bool isGet = _dict.TryGetValue(_key, out var value);

      if (isGet == false)
      {
        return;
      }
      value.Clear();
    }

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key, Action<TValue> _act)
    {
      bool isGet = _dict.TryGetValue(_key, out var list);

      if (isGet == false)
      {
        return;
      }
      list.ForEach(_act);
    }

    public static bool Remove<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var list);

      if (isGet == false)
      {
        return false;
      }
      return list.Remove(_value);
    }

    public static int RemoveWhere<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key, Predicate<TValue> _func)
    {
      bool isGet = _dict.TryGetValue(_key, out var list);

      if (isGet == false)
      {
        return 0;
      }
      return list.RemoveAll(_func);
    }

    public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, List<TValue>> _dict, TKey _key, int _index, out TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var list);

      if (isGet == false)
      {
        _value = default;
        return false;
      }
      return list.TryGetValue(_index, out _value);
    }
    #endregion

    #region IDictionary<TKey, HashSet<TValue>>

    public static bool Add<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> _dict, TKey _key, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var hashSet);

      if (isGet == false)
      {
        hashSet = new HashSet<TValue>();
        hashSet.Add(_value);
        _dict.Add(_key, hashSet);
        return true;
      }
      return hashSet.Add(_value);
    }

    public static void AddRange<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> _dict, TKey _key, HashSet<TValue> _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var hashSet);

      if (isGet == false)
      {
        _dict.Add(_key, _value);
        return;
      }
      hashSet.AddRange(_value);
    }

    public static void Clear<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> _dict, TKey _key)
    {
      bool isGet = _dict.TryGetValue(_key, out var value);

      if (isGet == false)
      {
        return;
      }
      value.Clear();
    }

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> _dict, TKey _key, Action<TValue> _act)
    {
      bool isGet = _dict.TryGetValue(_key, out var hashSet);

      if (isGet == false)
      {
        return;
      }
      hashSet.ForEach(_act);
    }

    public static bool Remove<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> _dict, TKey _key, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var hashSet);

      if (isGet == false)
      {
        return false;
      }
      return hashSet.Remove(_value);
    }

    public static int RemoveWhere<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> _dict, TKey _key, Predicate<TValue> _func)
    {
      bool isGet = _dict.TryGetValue(_key, out var hashSet);

      if (isGet == false)
      {
        return 0;
      }
      return hashSet.RemoveWhere(_func);
    }
    #endregion

    #region IDictionary<TKey, SortedSet<TValue>>

    public static bool Add<TKey, TValue>(this IDictionary<TKey, SortedSet<TValue>> _dict, TKey _key, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var sortedSet);

      if (isGet == false)
      {
        sortedSet = new SortedSet<TValue>();
        sortedSet.Add(_value);
        _dict.Add(_key, sortedSet);
        return true;
      }
      return sortedSet.Add(_value);
    }

    public static void Clear<TKey, TValue>(this IDictionary<TKey, SortedSet<TValue>> _dict, TKey _key)
    {
      bool isGet = _dict.TryGetValue(_key, out var sortedSet);

      if (isGet == false)
      {
        return;
      }
      sortedSet.Clear();
    }

    public static bool Remove<TKey, TValue>(this IDictionary<TKey, SortedSet<TValue>> _dict, TKey _key, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key, out var sortedSet);

      if (isGet == false)
      {
        return false;
      }
      return sortedSet.Remove(_value);
    }
    #endregion

    #region IDictionary<TKey1, Dictionary<TKey2, TValue>>

    public static void Add<TKey1, TKey2, TValue>(this IDictionary<TKey1, Dictionary<TKey2, TValue>> _dict, TKey1 _key1, TKey2 _key2, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key1, out var dict);

      if (isGet == false)
      {
        dict = new Dictionary<TKey2, TValue>();
        dict.Add(_key2, _value);
        _dict.Add(_key1, dict);
        return;
      }
      dict.Add(_key2, _value);
    }

    public static bool TryAdd<TKey1, TKey2, TValue>(this IDictionary<TKey1, Dictionary<TKey2, TValue>> _dict, TKey1 _key1, TKey2 _key2, TValue _value)
    {
      bool isGet = _dict.TryGetValue(_key1, out var dict);

      if (isGet == false)
      {
        dict = new Dictionary<TKey2, TValue>();
        dict.Add(_key2, _value);
        _dict.Add(_key1, dict);
        return true;
      }

      return dict.TryAdd(_key2, _value);
    }
    #endregion

    #region IEnumerable

    public static string Concat<TSource>(this IEnumerable<TSource> _coll)
    {
      return string.Concat(_coll);
    }

    public static string Join<TSource>(this IEnumerable<TSource> _coll, string _sep)
    {
      return string.Join(_sep, _coll);
    }

    public static void ForEach<TSource>(this IEnumerable<TSource> _coll, Action<TSource> _act)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current);
      }
      iterator.Dispose();
    }

    public static void ForEach<TSource>(this IEnumerable<(TSource, TSource)> _coll, Action<TSource> _act)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Item2);
      }
      iterator.Dispose();
    }

    public static void ForEach<TItem1, TItem2>(this IEnumerable<(TItem1, TItem2)> _coll, Action<TItem1> _act)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Item1);
      }
      iterator.Dispose();
    }

    public static void ForEach<TItem1, TItem2>(this IEnumerable<(TItem1, TItem2)> _coll, Action<TItem2> _act)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Item2);
      }
      iterator.Dispose();
    }

    public static void ForEach<TItem1, TItem2>(this IEnumerable<(TItem1, TItem2)> _coll, Action<TItem1, TItem2> _act)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Item1, iterator.Current.Item2);
      }
      iterator.Dispose();
    }

    public static void ForEach<TSource>(this IEnumerable<KeyValuePair<TSource, TSource>> _dict, Action<TSource> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Value);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _dict, Action<TKey> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Key);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _dict, Action<TValue> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Value);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _dict, Action<TKey, TValue> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _act.Invoke(iterator.Current.Key, iterator.Current.Value);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, List<TValue>>> _dict, Action<TValue> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        iterator.Current.Value.ForEach(_act);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, HashSet<TValue>>> _dict, Action<TValue> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        iterator.Current.Value.ForEach(_act);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, List<TValue>>> _dict, Action<TKey, TValue> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        var sub = iterator.Current.Value.GetEnumerator();

        while (sub.MoveNext())
        {
          _act.Invoke(iterator.Current.Key, sub.Current);
        }
        sub.Dispose();
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, HashSet<TValue>>> _dict, Action<TKey, TValue> _act)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        var sub = iterator.Current.Value.GetEnumerator();

        while (sub.MoveNext())
        {
          _act.Invoke(iterator.Current.Key, sub.Current);
        }
        sub.Dispose();
      }
      iterator.Dispose();
    }

    public static void ForEach<TSource, TResult>(this IEnumerable<TSource> _coll, Func<TSource, TResult> _func)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current);
      }
      iterator.Dispose();
    }

    public static void ForEach<TSource, TResult>(this IEnumerable<(TSource, TSource)> _coll, Func<TSource, TResult> _func)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Item2);
      }
      iterator.Dispose();
    }

    public static void ForEach<TItem1, TItem2, TResult>(this IEnumerable<(TItem1, TItem2)> _coll, Func<TItem1, TResult> _func)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Item1);
      }
      iterator.Dispose();
    }

    public static void ForEach<TItem1, TItem2, TResult>(this IEnumerable<(TItem1, TItem2)> _coll, Func<TItem2, TResult> _func)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Item2);
      }
      iterator.Dispose();
    }

    public static void ForEach<TItem1, TItem2, TResult>(this IEnumerable<(TItem1, TItem2)> _coll, Func<TItem1, TItem2, TResult> _func)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Item1, iterator.Current.Item2);
      }
      iterator.Dispose();
    }

    public static void ForEach<TSource, TResult>(this IEnumerable<KeyValuePair<TSource, TSource>> _dict, Func<TSource, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Value);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, TValue>> _dict, Func<TKey, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Key);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, TValue>> _dict, Func<TValue, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Value);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, TValue>> _dict, Func<TKey, TValue, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        _func.Invoke(iterator.Current.Key, iterator.Current.Value);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, List<TValue>>> _dict, Func<TValue, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        iterator.Current.Value.ForEach(_func);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, HashSet<TValue>>> _dict, Func<TValue, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        iterator.Current.Value.ForEach(_func);
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, List<TValue>>> _dict, Func<TKey, TValue, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        var sub = iterator.Current.Value.GetEnumerator();

        while (sub.MoveNext())
        {
          _func.Invoke(iterator.Current.Key, sub.Current);
        }
        sub.Dispose();
      }
      iterator.Dispose();
    }

    public static void ForEach<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, HashSet<TValue>>> _dict, Func<TKey, TValue, TResult> _func)
    {
      var iterator = _dict.GetEnumerator();

      while (iterator.MoveNext())
      {
        var sub = iterator.Current.Value.GetEnumerator();

        while (sub.MoveNext())
        {
          _func.Invoke(iterator.Current.Key, sub.Current);
        }
        sub.Dispose();
      }
      iterator.Dispose();
    }

    public static TSource Peek<TSource>(this IEnumerable<TSource> _coll)
    {
      var iterator = _coll.GetEnumerator();
      iterator.MoveNext();

      TSource result = iterator.Current;
      iterator.Dispose();
      return result;
    }

    public static bool TrueForAll(this IEnumerable<bool> _coll)
    {
      var iterator = _coll.GetEnumerator();

      while (iterator.MoveNext())
      {
        if (iterator.Current == false)
        {
          iterator.Dispose();
          return false;
        }
      }

      iterator.Dispose();
      return true;
    }
    #endregion

    #region HashSet

    public static void AddRange<TSource>(this HashSet<TSource> _hashSet, IEnumerable<TSource> _coll)
    {
      if (_coll == null)
      {
        return;
      }
      _hashSet.UnionWith(_coll);
    }

    public static void AddRange<TSource>(this HashSet<string> _hashSet, string _str, params char[] _seps)
    {
      string[] strs = _str.TrySplit(_seps);
      _hashSet.AddRange(strs);
    }
    #endregion

    #region List

    public static void AddRange(this List<string> _list, string _str, params char[] _seps)
    {
      string[] strs = _str.TrySplit(_seps);
      _list.AddRange(strs);
    }

    public static TSource GetFirst<TSource>(this IList<TSource> _list)
    {
      int count = _list.Count;

      if (count == 0)
      {
        return default;
      }
      return _list[0];
    }

    public static TSource GetLast<TSource>(this IList<TSource> _list)
    {
      int count = _list.Count;

      if (count == 0)
      {
        return default;
      }
      return _list[count - 1];
    }

    public static void RemoveFirst<TSource>(this IList<TSource> _list)
    {
      int count = _list.Count;

      if (count == 0)
      {
        return;
      }
      _list.RemoveAt(0);
    }

    public static void RemoveLast<TSource>(this IList<TSource> _list)
    {
      int count = _list.Count;

      if (count == 0)
      {
        return;
      }
      _list.RemoveAt(count - 1);
    }

    public static bool TrueForAll(this List<bool> _list)
    {
      return _list.TrueForAll(result => result);
    }

    public static bool TryGetValue<TSource>(this IList<TSource> _list, int _index, out TSource _result)
    {
      _result = default;

      if (_index >= _list.Count)
      {
        return false;
      }

      if (_index < 0)
      {
        return false;
      }

      _result = _list[_index];
      return true;
    }
    #endregion

    #region Queue

    public static TSource TryPeek<TSource>(this Queue<TSource> _que)
    {
      if (_que.Count == 0)
      {
        return default;
      }
      return _que.Peek();
    }

    public static TSource TryDequeue<TSource>(this Queue<TSource> _que)
    {
      if (_que.Count == 0)
      {
        return default;
      }
      return _que.Dequeue();
    }
    #endregion

    #region Stack

    public static TSource TryPeek<TSource>(this Stack<TSource> _stk)
    {
      if (_stk.Count == 0)
      {
        return default;
      }
      return _stk.Peek();
    }

    public static TSource TryPop<TSource>(this Stack<TSource> _stk)
    {
      if (_stk.Count == 0)
      {
        return default;
      }
      return _stk.Pop();
    }
    #endregion
  }
}