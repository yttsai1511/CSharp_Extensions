using System;

namespace System.Extensions
{
  public static class TimeExtensions
  {
    #region DateTime

    public static double GetRemainMinutes(this DateTime _date)
    {
      TimeSpan day = TimeSpan.FromDays(1d);
      return day.GetSpanMinutes(_date.TimeOfDay);
    }

    public static double GetRemainSeconds(this DateTime _date)
    {
      TimeSpan day = TimeSpan.FromDays(1d);
      return day.GetSpanSeconds(_date.TimeOfDay);
    }

    public static double GetSpanMinutes(this DateTime _date, DateTime _value)
    {
      return _date.Subtract(_value).TotalMinutes;
    }

    public static double GetSpanSeconds(this DateTime _date, DateTime _value)
    {
      return _date.Subtract(_value).TotalSeconds;
    }

    public static string GetWeekString(this DateTime _date)
    {
      DayOfWeek week = _date.DayOfWeek;
      return week.GetName();
    }

    public static long ToUnixTime(this DateTime _date)
    {
      DateTimeOffset offset = new DateTimeOffset(_date);
      return offset.ToUnixTimeSeconds();
    }
    #endregion

    #region TimeSpan

    public static double GetSpanMinutes(this TimeSpan _span, TimeSpan _value)
    {
      return _span.Subtract(_value).TotalMinutes;
    }

    public static double GetSpanSeconds(this TimeSpan _span, TimeSpan _value)
    {
      return _span.Subtract(_value).TotalSeconds;
    }
    #endregion
  }
}