using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace System.Extensions
{
  public static class BinaryExtensions
  {
    #region BinaryWriter

    public static void Write(this BinaryWriter _writer, byte[] _data, int _buffer)
    {
      int length = _data.Length;
      int count = length / _buffer;
      int flush = count * _buffer;

      for (int index = 0; index < count; index++)
      {
        _writer.Write(_data, index * _buffer, _buffer);
        _writer.Flush();
      }

      length -= flush;

      if (length > 0)
      {
        _writer.Write(_data, flush, length);
      }
      _writer.Flush();
    }
    #endregion

    #region Byte

    public static byte[] FromAES(this byte[] _data, string _key)
    {
      return FromAES(_data, _key, _key);
    }

    public static byte[] FromAES(this byte[] _data, string _key, string _iv)
    {
      Aes crypto = Aes.Create();
      crypto.Key = _key.ToUTF8();
      crypto.IV = _iv.ToUTF8();
      ICryptoTransform trans = crypto.CreateDecryptor();
      byte[] result = trans.TransformFinalBlock(_data, 0, _data.Length);
      crypto.Clear();
      return result;
    }

    public static byte[] ToAES(this byte[] _data, string _key)
    {
      return ToAES(_data, _key, _key);
    }

    public static byte[] ToAES(this byte[] _data, string _key, string _iv)
    {
      Aes crypto = Aes.Create();
      crypto.Key = _key.ToUTF8();
      crypto.IV = _iv.ToUTF8();
      ICryptoTransform trans = crypto.CreateEncryptor();
      byte[] result = trans.TransformFinalBlock(_data, 0, _data.Length);
      crypto.Clear();
      return result;
    }

    public static string ToBase64(this byte[] _data)
    {
      return Convert.ToBase64String(_data);
    }

    public static string ToHex(this byte[] _data)
    {
      return BitConverter.ToString(_data);
    }

    public static byte[] ToMD5(this byte[] _data)
    {
      MD5 crypto = MD5.Create();
      byte[] result = crypto.ComputeHash(_data);
      crypto.Clear();
      return result;
    }

    public static string ToUTF8(this byte[] _data)
    {
      return Encoding.UTF8.GetString(_data);
    }
    #endregion
  }
}