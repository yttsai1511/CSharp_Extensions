using System;
using System.Collections.Generic;
using System.Text;

namespace System.Extensions
{
  public static class StringExtensions
  {
    #region Enum

    public static string GetName<TEnum>(this TEnum _source)
        where TEnum : Enum
    {
      return Enum.GetName(typeof(TEnum), _source);
    }

    public static string GetValue<TEnum>(this TEnum _source)
        where TEnum : Enum
    {
      return _source.ToInt().ToString();
    }

    public static string GetValue<TEnum>(this TEnum _source, string _format)
        where TEnum : Enum
    {
      return _source.ToInt().ToString(_format);
    }

    public static string Format<TEnum>(this TEnum _source, string _format)
        where TEnum : Enum
    {
      return Enum.Format(typeof(TEnum), _source, _format);
    }

    public static int ToInt<TEnum>(this TEnum _source)
      where TEnum : Enum
    {
      return _source.GetHashCode();
    }
    #endregion

    #region String

    public static bool Compare(this string _src, string _str)
    {
      return _src.Compare(_str, true);
    }

    public static bool Compare(this string _src, string _str, bool _ignoreCase)
    {
      return string.Compare(_src, _str, _ignoreCase) == 0;
    }

    public static string Concat(this string _src)
    {
      return string.Concat(_src, string.Empty);
    }

    public static string Concat(this string _src, string _str)
    {
      return string.Concat(_src, _str);
    }

    public static string Concat(this string _src, string _arg1, string _arg2)
    {
      return string.Concat(_src, _arg1, _arg2);
    }

    public static string Concat(this string _src, string _arg1, string _arg2, string _arg3)
    {
      return string.Concat(_src, _arg1, _arg2, _arg3);
    }

    public static string Concat(this string _src, params object[] _strs)
    {
      return string.Concat(_src, string.Concat(_strs));
    }

    public static string Format(this string _src, string _str)
    {
      return string.Format(_src, _str);
    }

    public static string Format(this string _src, string _arg1, string _arg2)
    {
      return string.Format(_src, _arg1, _arg2);
    }

    public static string Format(this string _src, string _arg1, string _arg2, string _arg3)
    {
      return string.Format(_src, _arg1, _arg2, _arg3);
    }

    public static string Format(this string _src, params object[] _strs)
    {
      return string.Format(_src, _strs);
    }

    public static bool IsDefined<TEnum>(this string _str)
        where TEnum : Enum
    {
      return Enum.IsDefined(typeof(TEnum), _str);
    }

    public static bool IsNullOrEmpty(this string _str)
    {
      return string.IsNullOrEmpty(_str);
    }

    public static bool IsNullOrWhiteSpace(this string _str)
    {
      return string.IsNullOrWhiteSpace(_str);
    }

    public static bool IsLetterOrDigit(this string _str)
    {
      if (_str == null)
      {
        return false;
      }

      for (int index = 0, size = _str.Length; index < size; index++)
      {
        bool isPass = char.IsLetterOrDigit(_str, index);

        if (isPass == false)
        {
          return false;
        }
      }
      return true;
    }

    public static string Join(this string _src, params object[] _strs)
    {
      return string.Join(_src, _strs);
    }

    public static string Remove(this string _src, string _str)
    {
      bool isEmpty = _src.IsNullOrEmpty();

      if (isEmpty == true)
      {
        return string.Empty;
      }
      return _src.Replace(_str, string.Empty);
    }

    public static string[] TrySplit(this string _src, params string[] _seps)
    {
      bool isEmpty = _src.IsNullOrEmpty();

      if (isEmpty == true)
      {
        return new string[0];
      }
      return _src.Split(_seps, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] TrySplit(this string _src, params char[] _seps)
    {
      bool isEmpty = _src.IsNullOrEmpty();

      if (isEmpty == true)
      {
        return new string[0];
      }
      return _src.Split(_seps, StringSplitOptions.RemoveEmptyEntries);
    }

    public static byte[] ToBase64(this string _str)
    {
      return Convert.FromBase64String(_str);
    }

    public static bool ToBool(this string _str)
    {

      bool.TryParse(_str, out bool value);
      return value;
    }

    public static double ToDouble(this string _str)
    {
      double.TryParse(_str, out double value);
      return value;
    }

    public static TEnum ToEnum<TEnum>(this string _str)
        where TEnum : struct, Enum
    {
      Enum.TryParse(_str, true, out TEnum value);
      return value;
    }

    public static float ToFloat(this string _str)
    {
      float.TryParse(_str, out float value);
      return value;
    }

    public static int ToInt(this string _str)
    {
      int.TryParse(_str, out int value);
      return value;
    }

    public static long ToLong(this string _str)
    {
      long.TryParse(_str, out long value);
      return value;
    }

    public static string ToLower(this string _src, int _index)
    {
      if (_index >= _src.Length)
      {
        return _src;
      }

      if (_index < 0)
      {
        return _src;
      }

      char[] chars = _src.ToCharArray();
      chars[_index] = char.ToLower(chars[_index]);
      return new string(chars);
    }

    public static string ToUpper(this string _src, int _index)
    {
      if (_index >= _src.Length)
      {
        return _src;
      }

      if (_index < 0)
      {
        return _src;
      }

      char[] chars = _src.ToCharArray();
      chars[_index] = char.ToUpper(chars[_index]);
      return new string(chars);
    }

    public static byte[] ToUTF8(this string _str)
    {
      return Encoding.UTF8.GetBytes(_str);
    }

    public static List<string> ToList(this string _src, params char[] _seps)
    {
      string[] strs = _src.TrySplit(_seps);
      return new List<string>(strs);
    }

    public static HashSet<string> ToSet(this string _src, params char[] _seps)
    {
      string[] strs = _src.TrySplit(_seps);
      return new HashSet<string>(strs);
    }

    public static List<TEnum> ToEnumList<TEnum>(this string _src, params char[] _seps)
        where TEnum : struct, Enum
    {
      string[] strs = _src.TrySplit(_seps);
      List<TEnum> list = new List<TEnum>();

      foreach (string obj in strs)
      {
        list.Add(obj.ToEnum<TEnum>());
      }
      return list;
    }

    public static HashSet<TEnum> ToEnumSet<TEnum>(this string _src, params char[] _seps)
        where TEnum : struct, Enum
    {
      string[] strs = _src.TrySplit(_seps);
      HashSet<TEnum> hashSet = new HashSet<TEnum>();

      foreach (string obj in strs)
      {
        hashSet.Add(obj.ToEnum<TEnum>());
      }
      return hashSet;
    }

    public static List<float> ToFloatList(this string _src, params char[] _seps)
    {
      string[] strs = _src.TrySplit(_seps);
      List<float> list = new List<float>();

      foreach (string obj in strs)
      {
        list.Add(obj.ToFloat());
      }
      return list;
    }

    public static HashSet<float> ToFloatSet(this string _src, params char[] _seps)
    {
      string[] strs = _src.TrySplit(_seps);
      HashSet<float> hashSet = new HashSet<float>();

      foreach (string obj in strs)
      {
        hashSet.Add(obj.ToFloat());
      }
      return hashSet;
    }

    public static List<int> ToIntList(this string _src, params char[] _seps)
    {
      string[] strs = _src.TrySplit(_seps);
      List<int> list = new List<int>();

      foreach (string obj in strs)
      {
        list.Add(obj.ToInt());
      }
      return list;
    }

    public static HashSet<int> ToIntSet(this string _src, params char[] _seps)
    {
      string[] strs = _src.TrySplit(_seps);
      HashSet<int> hashSet = new HashSet<int>();

      foreach (string obj in strs)
      {
        hashSet.Add(obj.ToInt());
      }
      return hashSet;
    }

    public static string TrySub(this string _src, int _index)
    {
      if (_index >= _src.Length)
      {
        return string.Empty;
      }
      return _src.Substring(_index);
    }

    public static string TrySub(this string _src, int _index, int _length)
    {
      if (_index + _length > _src.Length)
      {
        return string.Empty;
      }
      return _src.Substring(_index, _length);
    }
    #endregion

    #region StringBuilder

    public static void Remove(this StringBuilder _source, string _str)
    {
      _source.Replace(_str, string.Empty);
    }
    #endregion
  }
}