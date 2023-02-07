using System;
using System.Reflection;

namespace System.Extensions.Reflection
{
  public static class ReflectionExtensions
  {
    #region Object

    public static TSource GetFieldValue<TSource>(this object _obj, string _name)
    {
      return (TSource)_obj.GetFieldValue(_name);
    }

    public static object GetFieldValue(this object _obj, string _name)
    {
      Type type = _obj.GetType();
      BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      FieldInfo info = type.GetField(_name, flag);
      return info.GetValue(_obj);
    }

    public static TSource GetPropertyValue<TSource>(this object _obj, string _name)
    {
      return (TSource)_obj.GetPropertyValue(_name);
    }

    public static object GetPropertyValue(this object _obj, string _name)
    {
      Type type = _obj.GetType();
      BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      PropertyInfo info = type.GetProperty(_name, flag);
      return info.GetValue(_obj);
    }

    public static void SetFieldValue<TSource>(this ref TSource _obj, string _name, object _value)
       where TSource : struct
    {
      object result = _obj;
      result.SetFieldValue(_name, _value);
      _obj = (TSource)result;
    }

    public static void SetFieldValue(this object _obj, string _name, object _value)
    {
      Type type = _obj.GetType();
      BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      FieldInfo info = type.GetField(_name, flag);
      info.SetValue(_obj, _value);
    }

    public static void SetPropertyValue<TSource>(this ref TSource _obj, string _name, object _value)
       where TSource : struct
    {
      object result = _obj;
      result.SetFieldValue(_name, _value);
      _obj = (TSource)result;
    }

    public static void SetPropertyValue(this object _obj, string _name, object _value)
    {
      Type type = _obj.GetType();
      BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      PropertyInfo info = type.GetProperty(_name, flag);
      info.SetValue(_obj, _value);
    }
    #endregion

    #region Type

    public static TSource GetAttribute<TSource>(this Type _source)
       where TSource : Attribute
    {
      return Attribute.GetCustomAttribute(_source, typeof(TSource)) as TSource;
    }
    #endregion
  }
}