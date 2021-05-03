using System; 
using System.Security.Cryptography;
using System.Text;

namespace Event_Portal.Auth
{
    public class GenerateRandomName
    {
    public string RandomStr(int size, bool upperCase)
    {
      using (var r = new RNGCryptoServiceProvider())
      {
        StringBuilder builder = new StringBuilder();
        var data = new byte[size];
        r.GetNonZeroBytes(data);

        var b = @"0123456789abcdifghijklmnopqrstuvwxwzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdifghijklmnopqrstuvwxwzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdifghijklmnopqrstuvwxwzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdifghijklmnopqrstuvwxwzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456";

        for (int i = 0; i < data.Length; i++)
        {
          var c = b[data[i]];
          builder.Append((upperCase) ? char.ToUpperInvariant(c) : c);
        }
        return builder.ToString();
      }
    }
    }
}