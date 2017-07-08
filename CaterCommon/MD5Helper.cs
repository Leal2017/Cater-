using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
   public static class MD5Helper
    {
       public static string EncrytString(string str)
       {
           MD5 md5 = MD5.Create();
           byte[] byteOld = Encoding.UTF8.GetBytes(str);
           byte[] byteNew= md5.ComputeHash(byteOld);
           StringBuilder builder=new StringBuilder();
           foreach (byte b in byteNew)
           {
               builder.Append(b.ToString());
           }
           return builder.ToString();
       }
    }
}
