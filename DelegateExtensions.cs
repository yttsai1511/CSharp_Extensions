using System;
using System.Collections.Generic;

namespace System.Extensions
{
  public static class DelegateExtensions
  {
    #region Delegate

    public static TSource Combine<TSource>(this TSource _arg1, TSource _arg2)
        where TSource : Delegate
    {
      if (_arg1 == null)
      {
        return _arg2;
      }

      if (_arg2 == null)
      {
        return _arg1;
      }

      foreach (Delegate action in _arg1.GetInvocationList())
      {
        if (action.Target != _arg2.Target)
        {
          continue;
        }

        if (action.Method != _arg2.Method)
        {
          continue;
        }
        return _arg1;
      }
      return Delegate.Combine(_arg1, _arg2) as TSource;
    }

    public static TSource Remove<TSource>(this TSource _arg1, TSource _arg2)
        where TSource : Delegate
    {
      if (_arg1 == null)
      {
        return _arg1;
      }

      if (_arg2 == null)
      {
        return _arg1;
      }

      foreach (Delegate action in _arg1.GetInvocationList())
      {
        if (action.Target != _arg2.Target)
        {
          continue;
        }

        if (action.Method != _arg2.Method)
        {
          continue;
        }
        return Delegate.Remove(_arg1, action) as TSource;
      }
      return _arg1;
    }

    public static TSource Register<TSource>(this TSource _arg1, TSource _arg2, bool _isEnable)
        where TSource : Delegate
    {
      if (_isEnable == true)
      {
        return _arg1.Combine(_arg2);
      }
      else
      {
        return _arg1.Remove(_arg2);
      }
    }

    public static TResult TryInvoke<TResult>(this Func<TResult> _func)
    {
      if (_func == null)
      {
        return default;
      }
      return _func.Invoke();
    }

    public static TResult TryInvoke<TSource, TResult>(this Func<TSource, TResult> _func, TSource _src)
    {
      if (_func == null)
      {
        return default;
      }
      return _func.Invoke(_src);
    }

    public static TResult TryInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> _func, T1 _arg1, T2 _arg2)
    {
      if (_func == null)
      {
        return default;
      }
      return _func.Invoke(_arg1, _arg2);
    }

    public static TResult TryInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> _func, T1 _arg1, T2 _arg2, T3 _arg3)
    {
      if (_func == null)
      {
        return default;
      }
      return _func.Invoke(_arg1, _arg2, _arg3);
    }

    public static void GetResult<TResult>(this Func<TResult> _func, List<TResult> _list)
    {
      Delegate[] funcs = _func.GetInvocationList();

      foreach (Func<TResult> sub in funcs)
      {
        TResult result = sub.TryInvoke();
        _list?.Add(result);
      }
    }

    public static void GetResult<TSource, TResult>(this Func<TSource, TResult> _func, List<TResult> _list, TSource _src)
    {
      Delegate[] funcs = _func.GetInvocationList();

      foreach (Func<TSource, TResult> sub in funcs)
      {
        TResult result = sub.TryInvoke(_src);
        _list?.Add(result);
      }
    }

    public static void GetResult<T1, T2, TResult>(this Func<T1, T2, TResult> _func, List<TResult> _list, T1 _arg1, T2 _arg2)
    {
      Delegate[] funcs = _func.GetInvocationList();

      foreach (Func<T1, T2, TResult> sub in funcs)
      {
        TResult result = sub.TryInvoke(_arg1, _arg2);
        _list?.Add(result);
      }
    }

    public static void GetResult<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> _func, List<TResult> _list, T1 _arg1, T2 _arg2, T3 _arg3)
    {
      Delegate[] funcs = _func.GetInvocationList();

      foreach (Func<T1, T2, T3, TResult> sub in funcs)
      {
        TResult result = sub.TryInvoke(_arg1, _arg2, _arg3);
        _list?.Add(result);
      }
    }
    #endregion

    #region IDictionary<TKey, Delegate>

    public static void Combine<TKey, TValue>(this IDictionary<TKey, TValue> _dict, TKey _key, TValue _act)
        where TValue : Delegate
    {
      bool isGet = _dict.TryGetValue(_key, out TValue value);

      if (isGet == false)
      {
        _dict.Add(_key, _act);
        return;
      }
      _dict[_key] = value.Combine(_act);
    }

    public static void Remove<TKey, TValue>(this IDictionary<TKey, TValue> _dict, TKey _key, TValue _act)
        where TValue : Delegate
    {
      bool isGet = _dict.TryGetValue(_key, out TValue value);

      if (isGet == false)
      {
        return;
      }
      _dict[_key] = value.Remove(_act);
    }

    public static void Register<TKey, TValue>(this IDictionary<TKey, TValue> _dict, TKey _key, TValue _act, bool _isEnable)
        where TValue : Delegate
    {
      if (_isEnable == true)
      {
        _dict.Combine(_key, _act);
      }
      else
      {
        _dict.Remove(_key, _act);
      }
    }

    public static void Invoke<TKey, TValue>(this IDictionary<TKey, TValue> _dict, TKey _key)
        where TValue : Delegate
    {
      bool isGet = _dict.TryGetValue(_key, out TValue value);

      if (isGet == false)
      {
        return;
      }

      var act = value as Action;
      act?.Invoke();
    }

    public static void Invoke<TKey, TValue, TSource>(this IDictionary<TKey, TValue> _dict, TKey _key, TSource _src)
        where TValue : Delegate
    {
      bool isGet = _dict.TryGetValue(_key, out TValue value);

      if (isGet == false)
      {
        return;
      }

      var act = value as Action<TSource>;
      act?.Invoke(_src);
    }

    public static void Invoke<TKey, TValue, T1, T2>(this IDictionary<TKey, TValue> _dict, TKey _key, T1 _arg1, T2 _arg2)
        where TValue : Delegate
    {
      bool isGet = _dict.TryGetValue(_key, out TValue value);

      if (isGet == false)
      {
        return;
      }

      var act = value as Action<T1, T2>;
      act?.Invoke(_arg1, _arg2);
    }

    public static void Invoke<TKey, TValue, T1, T2, T3>(this IDictionary<TKey, TValue> _dict, TKey _key, T1 _arg1, T2 _arg2, T3 _arg3)
        where TValue : Delegate
    {
      bool isGet = _dict.TryGetValue(_key, out TValue value);

      if (isGet == false)
      {
        return;
      }

      var act = value as Action<T1, T2, T3>;
      act?.Invoke(_arg1, _arg2, _arg3);
    }
    #endregion
  }
}