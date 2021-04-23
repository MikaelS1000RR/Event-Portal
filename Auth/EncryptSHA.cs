using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;


namespace Event_Portal.Auth
{
  public class EncryptSHA 
  {
    public static string GetShaData(string data)
    {
      SHA1 sha = SHA1.Create();
      Byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(data));
      StringBuilder returnValue = new StringBuilder();
      int i;
      for (i = 0; i < hashData.Length-1; i++)
      {
        returnValue.Append(hashData[i].ToString());

      }
      return returnValue.ToString();
    }
  }
}