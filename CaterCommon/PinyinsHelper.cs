using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.International.Converters.PinYinConverter;

namespace CaterCommon
{
  public static class PinyinsHelper
    {
      public static string GetFirstLetter(string str)
      {
          string s1 = string.Empty;
          foreach (char c in str)
          {
             ChineseChar cc=new ChineseChar(c);
             //var s2= cc.Pinyins[0][0];
             //s1 = s2.ToString();
              s1 += cc.Pinyins[0][0];
          }
          return s1;
      }
    }
}
