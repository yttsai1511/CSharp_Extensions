using System;
using System.Collections.Generic;
using System.Extensions.Reflection;
using System.Reflection;

namespace System.Extensions.Debugging
{
  public static class DebugExtensions
  {
    public static TSource[] Concat<TSource>(this TSource[] _dest, TSource[] _src)
    {
      int index = _dest.Length;
      int length = index + _src.Length;
      Array.Resize(ref _dest, length);
      _src.CopyTo(_dest, index);
      return _dest;
    }

    public static TSource[] GetRuntimeArray<TSource>(this List<TSource> _list)
    {
      string name = "_items";
      return _list.GetFieldValue(name) as TSource[];
    }

    public static void PopulateField<TSource>(this ref TSource _dest, object _src)
        where TSource : struct
    {
      object result = _dest;
      result.PopulateField(_src);
      _dest = (TSource)result;
    }

    public static void PopulateField(this object _dest, object _src)
    {
      Type srcType = _src.GetType();
      Type destType = _dest.GetType();
      BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      FieldInfo[] srcFields = srcType.GetFields(flag);
      FieldInfo[] destFields = destType.GetFields(flag);

      foreach (var srcField in srcFields)
      {
        foreach (var destField in destFields)
        {
          if (srcField.Name != destField.Name)
          {
            continue;
          }

          if (srcField.FieldType != destField.FieldType)
          {
            continue;
          }

          destField.SetValue(_dest, srcField.GetValue(_src));
          break;
        }
      }
    }

    public static TSource Seek<TSource>(this TSource _obj)
    {
      return _obj;
    }
  }
}