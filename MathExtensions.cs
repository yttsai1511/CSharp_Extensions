using System;

namespace System.Extensions
{
  public static class MathExtensions
  {
    #region Boolean

    public static int ToInt(this bool _value)
    {
      return Convert.ToInt32(_value);
    }

    public static float ToFloat(this bool _value)
    {
      return Convert.ToSingle(_value);
    }
    #endregion

    #region Double

    public static double Round(this double _value)
    {
      return Math.Round(_value, MidpointRounding.AwayFromZero);
    }

    public static double Round(this double _value, int _digit)
    {
      return Math.Round(_value, _digit, MidpointRounding.AwayFromZero);
    }

    public static double Truncate(this double _value)
    {
      return Math.Truncate(_value);
    }

    public static float ToFloat(this double _value)
    {
      return Convert.ToSingle(_value);
    }

    public static int ToInt(this double _value)
    {
      return Convert.ToInt32(_value);
    }
    #endregion

    #region Float

    public static float Abs(this float _value)
    {
      return Math.Abs(_value);
    }

    public static float Clamp(this float _value, float _min, float _max)
    {
      return Math.Clamp(_value, _min, _max);
    }

    public static float ClampNaN(this float _value)
    {
      if (float.IsInfinity(_value) == true)
      {
        return 0f;
      }

      if (float.IsNaN(_value) == true)
      {
        return 0f;
      }
      return _value;
    }

    public static float Distance(this float _src, float _dest)
    {
      return Math.Abs(_dest - _src);
    }

    public static float Round(this float _value)
    {
      return Math.Round(_value, MidpointRounding.AwayFromZero).ToFloat();
    }

    public static float Round(this float _value, int _digit)
    {
      return Math.Round(_value, _digit, MidpointRounding.AwayFromZero).ToFloat();
    }

    public static float Truncate(this float _value)
    {
      return Math.Truncate(_value).ToFloat();
    }

    public static bool ToBoolean(this float _value)
    {
      return Convert.ToBoolean(_value);
    }

    public static int ToInt(this float _value)
    {
      return Convert.ToInt32(_value);
    }
    #endregion

    #region Integer

    public static int Abs(this int _value)
    {
      return Math.Abs(_value);
    }

    public static int Clamp(this int _value, int _min, int _max)
    {
      return Math.Clamp(_value, _min, _max);
    }

    public static bool IsDefined<TEnum>(this int _value)
       where TEnum : Enum
    {
      TEnum obj = ToEnum<TEnum>(_value);
      string name = obj.GetName();
      return name != null;
    }

    public static bool ToBoolean(this int _value)
    {
      return Convert.ToBoolean(_value);
    }

    public static TEnum ToEnum<TEnum>(this int _value)
       where TEnum : Enum
    {
      return (TEnum)Enum.ToObject(typeof(TEnum), _value);
    }
    #endregion

    #region Long

    public static int ToInt(this long _value)
    {
      return Convert.ToInt32(_value);
    }
    #endregion
  }
}